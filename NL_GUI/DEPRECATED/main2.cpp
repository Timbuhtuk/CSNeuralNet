#include "pipe_writer.h"
#include <string>

int main(int argc, char* argv[])
{
    std::string str{"default str"};

    if (argc > 1)
    {
        str = argv[1];
    }

    PipeWriter writer{"mynamedpipe"};

    writer.write(str);

    return 0;
}
