#include "config_writer.h"

#include <iostream>
#include <fstream>
#include <sstream>
#include <QDebug>

//TODO : use either QMap for storing values or QConfig

ConfigWriter::ConfigWriter() : m_configPath{"Config.txt"}
{
    load();

}

void ConfigWriter::update(const QString& path)
{

    qInfo() << "updating " << path << "with: \n" << m_configString;
    std::ofstream ofile{path.toStdString()}; //, std::ios::trunc};
    ofile << m_configString.toStdString();

}

QVariant ConfigWriter::getEntry(QVariant index) const
{
    auto str{m_configString.split('\n')[index.toInt()]};
    auto entry{str.split(" = ")[0]};

    return QVariant::fromValue(entry);

}


QVariant ConfigWriter::getValue(int index) const
{
    auto str{m_configString.split('\n')[index]};
    auto value{str.split(" = ")[1]};

    return QVariant::fromValue(value);

}

void ConfigWriter::load(const QString& path)
{
    m_configString.clear();
    std::ifstream ifile{path.toStdString()};
    std::string line;
    while (std::getline(ifile, line))
    {
        m_configString += QString::fromStdString(line) + '\n';

    }
    ifile.close();

    qInfo() << "Loaded file with content " << m_configString;
}


QVariant ConfigWriter::getNumberOfEntries() const
{
    return QVariant::fromValue(m_configString.count('\n'));
}

QVariantMap ConfigWriter::convertToQMap(std::map<std::string, std::string> map)
{
    QVariantMap newMap;
    for (const auto& [key, value] : map)
    {
        newMap[QString::fromStdString(key)] = QString::fromStdString(value);
    }

    return newMap;
}

void ConfigWriter::setValue(const QString& key, const QString& value)
{
    std::string newFileContent;

    std::istringstream stream;
    stream.str(m_configString.toStdString());
    std::string line;
    while (std::getline(stream, line))
    {
        auto pos = line.find(key.toStdString());

        if (pos == std::string::npos)
        {
            newFileContent += line + '\n';
            continue;
        }

        newFileContent += key.toStdString() + " = " + value.toStdString() + '\n';

    }

    m_configString = QString::fromStdString(newFileContent);


}

void ConfigWriter::setValue(QVariant key, const QVariant value)
{
    std::string newFileContent;

    std::istringstream stream;
    stream.str(m_configString.toStdString());
    std::string line;
    while (std::getline(stream, line))
    {
        auto pos = line.find(key.toString().toStdString());

        if (pos == std::string::npos)
        {
            newFileContent += line + '\n';
            continue;
        }

        newFileContent += key.toString().toStdString() + " = " + value.toString().toStdString() + '\n';

    }

    m_configString = QString::fromStdString(newFileContent);


}

QVariant ConfigWriter::getValue(const QString& key) const
{
    std::istringstream stream;

    stream.str(m_configString.toStdString());
    std::string line;
    while (std::getline(stream, line))
    {
        auto pos = line.find(key.toStdString());

        if (pos != std::string::npos)
        {
            std::string key;
            std::string value;
            std::string delimiter{" = "};
            std::size_t delimiter_pos{line.find(delimiter)};

            key = line.substr(0, delimiter_pos);
            value = line.substr(delimiter_pos + delimiter.size(), line.size());

            std::cout << key << ' ' << value << '\n';

            return QVariant::fromValue(QString::fromStdString(value));
        }

    }


    return "";
}
