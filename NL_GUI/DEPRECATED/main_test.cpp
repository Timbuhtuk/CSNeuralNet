#include "write_config.h"

std::ostream& operator<<(std::ostream& out, std::map<std::string, std::string> map)
{
    for (const auto& [key, value] : map)
    {
        out << "[ " << key << ", " << value << " ]" << '\n';


    }

    return out;
}

int main()
{
    std::cout << Config::readAll("Config.txt") << '\n';

    return 0;
}
