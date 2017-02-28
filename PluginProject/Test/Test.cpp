// Test.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#include <iostream>
#include <ruby.h>


int main(int argc, char* argv[])
{
	ruby_init();

#ifdef _DEBUG
	char* options[] = { "-d" };
    int option_count = 1;
	void* node = ruby_options(option_count, options);
#endif


    int state;
    VALUE result;
    result = rb_eval_string_protect("puts 'Hello, world!'", &state);

    if (state)
    {
	    auto err = rb_errinfo();
        printf(StringValueCStr(err));
    }

    rewind(stdin);
    getchar();

	return ruby_cleanup(state);
}

