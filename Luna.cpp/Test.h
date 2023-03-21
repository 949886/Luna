#pragma once

#include <thread>

static const std::thread::id MAIN_THREAD_ID = std::this_thread::get_id();

extern "C" __declspec(dllexport) size_t __stdcall CurrentThreadID();
extern "C" __declspec(dllexport) bool __stdcall IsMainThread();

extern "C" __declspec(dllexport) int __stdcall Add(int n1, int n2);
extern "C" __declspec(dllexport) int __stdcall Sub(int n1, int n2);

class __declspec(dllexport) Test
{
public:
	Test(void);
	~Test(void);

	int Add(int n1, int n2);
	int Sub(int n1, int n2);
};
