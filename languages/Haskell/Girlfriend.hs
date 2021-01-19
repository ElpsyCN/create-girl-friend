-- Execute this program:
--   > ghc -o Girlfriend Girlfriend.hs
--   > ./Girlfriend
-- or
--   > ghci Girlfriend.hs
--   *Main> main

newtype Name = Name String
  deriving (Show, Ord, Eq)

data Gender = Boy | Girl
  deriving (Show, Eq)

data Person = Person Gender Name Lover
  deriving (Show)

data Lover
  = Lover Person
  | Nil
  deriving (Show)

fallInLoveWith :: Person -> Person -> (Person, Person)
fallInLoveWith a@(Person g1 n1 _) b@(Person g2 n2 _) =
  let a' = Person g1 n1 (Lover b)
   in let b' = Person g2 n2 (Lover a')
       in let a'' = Person g1 n1 (Lover b')
           in (a'', b')

_getLoveTypeStr :: Gender -> String
_getLoveTypeStr Boy = "女朋友"
_getLoveTypeStr Girl = "男朋友"

describe :: Person -> IO ()
describe (Person gender (Name name) Nil) =
  putStrLn $ name ++ "没有" ++ _getLoveTypeStr gender
describe me@(Person gender (Name name) (Lover (Person g (Name n) l))) =
  case l of
    Nil ->
      putStrLn $ name ++ "的单相思对象是" ++ n
    Lover (Person _ (Name n') _) ->
      if name == n'
        then putStrLn $ name ++ "的" ++ _getLoveTypeStr gender ++ "是" ++ n
        else putStrLn $ name ++ "好像被绿了"

main :: IO ()
main = do
  let me0 = Person Boy (Name "我") Nil
  let gf0 = Person Girl (Name "她") Nil
  let (me, gf) = me0 `fallInLoveWith` gf0
  describe me
