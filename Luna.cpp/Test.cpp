#include "pch.h"
#include "Test.h"

#include <iostream>

int __stdcall Add(int n1, int n2)
{
	return n1 + n2;
}

int __stdcall Sub(int n1, int n2)
{
	return n1 - n2;
}

size_t __stdcall CurrentThreadID()
{
	return std::hash<std::thread::id>{}(std::this_thread::get_id());
}

bool __stdcall IsMainThread()
{
	std::cout << "MAIN_THREAD_ID: " << MAIN_THREAD_ID << std::endl;
	std::cout << "CurrentThreadID: " << CurrentThreadID() << std::endl;
	std::cout << "Res: " << (std::this_thread::get_id() == MAIN_THREAD_ID) << std::endl;
	return std::this_thread::get_id() == MAIN_THREAD_ID;
}

Test::Test()
{
}


Test::~Test()
{
}


int Test::Add(int n1, int n2)
{
	return n1 + n2;
}

int Test::Sub(int n1, int n2)
{
	return n1 - n2;
}


