#ifndef CONFIG_WRITER_H
#define CONFIG_WRITER_H

#include <QObject>
#include <QString>
#include <QMap>
#include <QVariant>
#include <QVariantMap>
#include <QtQml/qqmlregistration.h>


#include <map>
#include <string>

class ConfigWriter : public QObject
{
private:
    Q_OBJECT
    QML_ELEMENT

    QString m_configPath;
    QString m_configString;

public:
    explicit ConfigWriter();

    Q_INVOKABLE void load(const QString& path = "Config.txt");
    Q_INVOKABLE void update(const QString& path = "Config.txt");

    Q_INVOKABLE QVariant getEntry(QVariant index) const;
    Q_INVOKABLE QVariant getValue(int index) const;
    Q_INVOKABLE QVariant getValue(const QString& key) const;
    Q_INVOKABLE QVariant getNumberOfEntries() const;

    Q_INVOKABLE void setValue(const QString& key, const QString& value);
    Q_INVOKABLE void setValue(QVariant key, QVariant value);


    QVariantMap convertToQMap(std::map<std::string, std::string>);


};

#endif
