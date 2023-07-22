#ifndef WRITE_CONFIG_H
#define WRITE_CONFIG_H

#include <string>
#include <fstream>
#include <iostream>
#include <map>


std::ostream& operator<<(std::ostream& out, std::map<std::string, std::string> map)
{
    for (const auto& [key, value] : map)
    {
        out << "[ " << key << ", " << value << " ]" << '\n';


    }

    return out;
}

namespace Config
{
    void write(const std::string& path, const std::string& entry, const std::string& value)
    {
        std::string newFileContent;

        std::ifstream file{"Config.txt"};
        std::string line;
        while (std::getline(file, line))
        {
            auto pos = line.find(entry);

            if (pos == std::string::npos)
            {
                newFileContent += line + '\n';
                continue;
            }

            newFileContent += entry + " = " + value + '\n';

        }
        file.close();

        std::ofstream ofile{"Config.txt"}; //, std::ios::trunc};
        ofile << newFileContent;

    }

    std::string read(const std::string& path, const std::string& entry)
    {
        std::ifstream file{"Config.txt"};
        std::string line;
        while (std::getline(file, line))
        {
            auto pos = line.find(entry);

            if (pos != std::string::npos)
            {
                std::string key;
                std::string value;
                std::string delimiter{" = "};
                std::size_t delimiter_pos{line.find(delimiter)};

                key = line.substr(0, delimiter_pos);
                value = line.substr(delimiter_pos + delimiter.size(), line.size());

                std::cout << key << ' ' << value << '\n';

                return value;
            }

        }

        file.close();

        return "";
    }

    std::map<std::string, std::string> readAll(const std::string& path)
    {
        std::ifstream file{"Config.txt"};
        std::string line;
        std::map<std::string, std::string> data;


        while (std::getline(file, line))
        {
            std::string key;
            std::string value;
            std::string delimiter{" = "};
            std::size_t delimiter_pos{line.find(delimiter)};

            key = line.substr(0, delimiter_pos);
            value = line.substr(delimiter_pos + delimiter.size(), line.size());

            data[key] = value;
        }

        file.close();

        return data;

    }


}

#endif
