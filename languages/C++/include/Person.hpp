#pragma once

#include <cstring>

class Person
{
private:
    char* name;
    int age;
public:
    Person(const char* name,int age=0);
    char* getName();
    int getAge();
};