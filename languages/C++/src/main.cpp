#include "Girl.hpp"
#include "Person.hpp"

int main()
{
    Person me("��");

    Girl girl("Ů����");

    girl.kiss(me);
    girl.fallInLoveWith(me);

    return 0;
}