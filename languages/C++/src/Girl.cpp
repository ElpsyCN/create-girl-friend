#include "Girl.hpp"
#include "Person.hpp"
#include <iostream>

void Girl::kiss(Person someone)
{
   std::cout<<"��"<<this->getName()<<"�� ������ ��"<<someone.getName()<<"����"<<std::endl;
}

void Girl::fallInLoveWith(Person someone)
{
   std::cout<<"��"<<this->getName()<<"�� �� ��"<<someone.getName()<<"�� ׹�밮�ӡ�"<<std::endl;;
}