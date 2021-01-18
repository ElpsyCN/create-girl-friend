#include "Person.hpp"
#include<cstring>

Person::Person(const char* name,int age)
{
    this->name = new char[strlen(name)+1];
    strcpy(this->name,name);
    this->age=age;
}

char* Person::getName()
{
    return name;
}

int Person::getAge()
{
    return age;
}