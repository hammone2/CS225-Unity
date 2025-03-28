#include <iostream>
#include "Header.h"

Object::Object() {
    cout << data << endl;
}

Object::~Object() {
    cout << "Object destroyed in c++ because Unity typically doesn't call destructors." << endl;
}

int main()
{
    Object o;
}