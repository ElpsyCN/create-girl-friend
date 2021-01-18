#include "Girl.hpp"
#include "Person.hpp"
#include <iostream>

void Girl::kiss(Person someone)
{
   std::cout<<"「"<<this->getName()<<"」 亲了下 「"<<someone.getName()<<"」。"<<std::endl;
}

void Girl::fallInLoveWith(Person someone)
{
   std::cout<<"「"<<this->getName()<<"」 与 「"<<someone.getName()<<"」 坠入爱河。"<<std::endl;;
}