#pragma once

#include "Person.hpp"

class Girl:Person
{
public:
    Girl(char* name,int age=0):Person(name,age){};
    void kiss(Person someone);
    void fallInLoveWith(Person someone);
};