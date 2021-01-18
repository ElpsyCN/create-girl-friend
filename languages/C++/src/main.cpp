#include "Girl.hpp"
#include "Person.hpp"

int main()
{
    Person me("我");

    Girl girl("女朋友");

    girl.kiss(me);
    girl.fallInLoveWith(me);

    return 0;
}