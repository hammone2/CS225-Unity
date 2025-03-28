#include <iostream>
#include "Header.h"
#include "AnotherHeader.h"

Object::Object() {
    data = "This object is created in c++ because C# doesn't have headers.";
}

Object::~Object() {
    cout << "Object destroyed in c++ because Unity typically doesn't call destructors." << endl;
}

void SubObject::DisplayData() {
    cout << data << endl;
}

int main()
{
    Object* o = new SubObject();
    o->DisplayData();
    delete o;
}