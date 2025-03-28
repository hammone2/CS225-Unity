#pragma once
#include <iostream>
using namespace std;

class Object{
protected:
	string data;
public:
	virtual void DisplayData() = 0;
	Object();
	~Object();
};