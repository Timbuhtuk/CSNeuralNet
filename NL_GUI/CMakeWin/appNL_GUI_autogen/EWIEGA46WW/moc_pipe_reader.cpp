/****************************************************************************
** Meta object code from reading C++ file 'pipe_reader.h'
**
** Created by: The Qt Meta Object Compiler version 68 (Qt 6.5.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../../../pipe_reader.h"
#include <QtCore/qmetatype.h>
#include <QtCore/QList>

#if __has_include(<QtCore/qtmochelpers.h>)
#include <QtCore/qtmochelpers.h>
#else
QT_BEGIN_MOC_NAMESPACE
#endif


#include <memory>

#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'pipe_reader.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 68
#error "This file was generated using the moc from 6.5.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

#ifndef Q_CONSTINIT
#define Q_CONSTINIT
#endif

QT_WARNING_PUSH
QT_WARNING_DISABLE_DEPRECATED
QT_WARNING_DISABLE_GCC("-Wuseless-cast")
namespace {

#ifdef QT_MOC_HAS_STRINGDATA
struct qt_meta_stringdata_CLASSPipeReaderENDCLASS_t {};
static constexpr auto qt_meta_stringdata_CLASSPipeReaderENDCLASS = QtMocHelpers::stringData(
    "PipeReader",
    "QML.Element",
    "auto",
    "startWorker",
    "",
    "dataFetched",
    "strChanged",
    "initDataFetched",
    "data",
    "weightDataFetched",
    "layer",
    "neuron",
    "weight",
    "value",
    "weightFetchedFlat",
    "number",
    "getResult",
    "str",
    "setStr",
    "st",
    "start"
);
#else  // !QT_MOC_HAS_STRING_DATA
struct qt_meta_stringdata_CLASSPipeReaderENDCLASS_t {
    uint offsetsAndSizes[42];
    char stringdata0[11];
    char stringdata1[12];
    char stringdata2[5];
    char stringdata3[12];
    char stringdata4[1];
    char stringdata5[12];
    char stringdata6[11];
    char stringdata7[16];
    char stringdata8[5];
    char stringdata9[18];
    char stringdata10[6];
    char stringdata11[7];
    char stringdata12[7];
    char stringdata13[6];
    char stringdata14[18];
    char stringdata15[7];
    char stringdata16[10];
    char stringdata17[4];
    char stringdata18[7];
    char stringdata19[3];
    char stringdata20[6];
};
#define QT_MOC_LITERAL(ofs, len) \
    uint(sizeof(qt_meta_stringdata_CLASSPipeReaderENDCLASS_t::offsetsAndSizes) + ofs), len 
Q_CONSTINIT static const qt_meta_stringdata_CLASSPipeReaderENDCLASS_t qt_meta_stringdata_CLASSPipeReaderENDCLASS = {
    {
        QT_MOC_LITERAL(0, 10),  // "PipeReader"
        QT_MOC_LITERAL(11, 11),  // "QML.Element"
        QT_MOC_LITERAL(23, 4),  // "auto"
        QT_MOC_LITERAL(28, 11),  // "startWorker"
        QT_MOC_LITERAL(40, 0),  // ""
        QT_MOC_LITERAL(41, 11),  // "dataFetched"
        QT_MOC_LITERAL(53, 10),  // "strChanged"
        QT_MOC_LITERAL(64, 15),  // "initDataFetched"
        QT_MOC_LITERAL(80, 4),  // "data"
        QT_MOC_LITERAL(85, 17),  // "weightDataFetched"
        QT_MOC_LITERAL(103, 5),  // "layer"
        QT_MOC_LITERAL(109, 6),  // "neuron"
        QT_MOC_LITERAL(116, 6),  // "weight"
        QT_MOC_LITERAL(123, 5),  // "value"
        QT_MOC_LITERAL(129, 17),  // "weightFetchedFlat"
        QT_MOC_LITERAL(147, 6),  // "number"
        QT_MOC_LITERAL(154, 9),  // "getResult"
        QT_MOC_LITERAL(164, 3),  // "str"
        QT_MOC_LITERAL(168, 6),  // "setStr"
        QT_MOC_LITERAL(175, 2),  // "st"
        QT_MOC_LITERAL(178, 5)   // "start"
    },
    "PipeReader",
    "QML.Element",
    "auto",
    "startWorker",
    "",
    "dataFetched",
    "strChanged",
    "initDataFetched",
    "data",
    "weightDataFetched",
    "layer",
    "neuron",
    "weight",
    "value",
    "weightFetchedFlat",
    "number",
    "getResult",
    "str",
    "setStr",
    "st",
    "start"
};
#undef QT_MOC_LITERAL
#endif // !QT_MOC_HAS_STRING_DATA
} // unnamed namespace

Q_CONSTINIT static const uint qt_meta_data_CLASSPipeReaderENDCLASS[] = {

 // content:
      11,       // revision
       0,       // classname
       1,   14, // classinfo
       9,   16, // methods
       1,  101, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       6,       // signalCount

 // classinfo: key, value
       1,    2,

 // signals: name, argc, parameters, tag, flags, initial metatype offsets
       3,    0,   70,    4, 0x06,    2 /* Public */,
       5,    1,   71,    4, 0x06,    3 /* Public */,
       6,    1,   74,    4, 0x06,    5 /* Public */,
       7,    1,   77,    4, 0x06,    7 /* Public */,
       9,    4,   80,    4, 0x06,    9 /* Public */,
      14,    2,   89,    4, 0x06,   14 /* Public */,

 // slots: name, argc, parameters, tag, flags, initial metatype offsets
      16,    1,   94,    4, 0x0a,   17 /* Public */,
      18,    1,   97,    4, 0x0a,   19 /* Public */,

 // methods: name, argc, parameters, tag, flags, initial metatype offsets
      20,    0,  100,    4, 0x02,   21 /* Public */,

 // signals: parameters
    QMetaType::Void,
    QMetaType::Void, QMetaType::QString,    4,
    QMetaType::Void, QMetaType::QString,    4,
    QMetaType::Void, QMetaType::QVariantList,    8,
    QMetaType::Void, QMetaType::QVariant, QMetaType::QVariant, QMetaType::QVariant, QMetaType::QVariant,   10,   11,   12,   13,
    QMetaType::Void, QMetaType::QVariant, QMetaType::QVariant,   15,   13,

 // slots: parameters
    QMetaType::Void, QMetaType::QString,   17,
    QMetaType::Void, QMetaType::QString,   19,

 // methods: parameters
    QMetaType::Void,

 // properties: name, type, flags
      17, QMetaType::QString, 0x00015103, uint(2), 0,

       0        // eod
};

Q_CONSTINIT const QMetaObject PipeReader::staticMetaObject = { {
    QMetaObject::SuperData::link<QObject::staticMetaObject>(),
    qt_meta_stringdata_CLASSPipeReaderENDCLASS.offsetsAndSizes,
    qt_meta_data_CLASSPipeReaderENDCLASS,
    qt_static_metacall,
    nullptr,
    qt_metaTypeArray<
        // property 'str'
        QString,
        // Q_OBJECT / Q_GADGET
        PipeReader,
        // method 'startWorker'
        void,
        // method 'dataFetched'
        void,
        QString,
        // method 'strChanged'
        void,
        QString,
        // method 'initDataFetched'
        void,
        QList<QVariant>,
        // method 'weightDataFetched'
        void,
        QVariant,
        QVariant,
        QVariant,
        QVariant,
        // method 'weightFetchedFlat'
        void,
        QVariant,
        QVariant,
        // method 'getResult'
        void,
        const QString &,
        // method 'setStr'
        void,
        const QString &,
        // method 'start'
        void
    >,
    nullptr
} };

void PipeReader::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        auto *_t = static_cast<PipeReader *>(_o);
        (void)_t;
        switch (_id) {
        case 0: _t->startWorker(); break;
        case 1: _t->dataFetched((*reinterpret_cast< std::add_pointer_t<QString>>(_a[1]))); break;
        case 2: _t->strChanged((*reinterpret_cast< std::add_pointer_t<QString>>(_a[1]))); break;
        case 3: _t->initDataFetched((*reinterpret_cast< std::add_pointer_t<QList<QVariant>>>(_a[1]))); break;
        case 4: _t->weightDataFetched((*reinterpret_cast< std::add_pointer_t<QVariant>>(_a[1])),(*reinterpret_cast< std::add_pointer_t<QVariant>>(_a[2])),(*reinterpret_cast< std::add_pointer_t<QVariant>>(_a[3])),(*reinterpret_cast< std::add_pointer_t<QVariant>>(_a[4]))); break;
        case 5: _t->weightFetchedFlat((*reinterpret_cast< std::add_pointer_t<QVariant>>(_a[1])),(*reinterpret_cast< std::add_pointer_t<QVariant>>(_a[2]))); break;
        case 6: _t->getResult((*reinterpret_cast< std::add_pointer_t<QString>>(_a[1]))); break;
        case 7: _t->setStr((*reinterpret_cast< std::add_pointer_t<QString>>(_a[1]))); break;
        case 8: _t->start(); break;
        default: ;
        }
    } else if (_c == QMetaObject::IndexOfMethod) {
        int *result = reinterpret_cast<int *>(_a[0]);
        {
            using _t = void (PipeReader::*)();
            if (_t _q_method = &PipeReader::startWorker; *reinterpret_cast<_t *>(_a[1]) == _q_method) {
                *result = 0;
                return;
            }
        }
        {
            using _t = void (PipeReader::*)(QString );
            if (_t _q_method = &PipeReader::dataFetched; *reinterpret_cast<_t *>(_a[1]) == _q_method) {
                *result = 1;
                return;
            }
        }
        {
            using _t = void (PipeReader::*)(QString );
            if (_t _q_method = &PipeReader::strChanged; *reinterpret_cast<_t *>(_a[1]) == _q_method) {
                *result = 2;
                return;
            }
        }
        {
            using _t = void (PipeReader::*)(QList<QVariant> );
            if (_t _q_method = &PipeReader::initDataFetched; *reinterpret_cast<_t *>(_a[1]) == _q_method) {
                *result = 3;
                return;
            }
        }
        {
            using _t = void (PipeReader::*)(QVariant , QVariant , QVariant , QVariant );
            if (_t _q_method = &PipeReader::weightDataFetched; *reinterpret_cast<_t *>(_a[1]) == _q_method) {
                *result = 4;
                return;
            }
        }
        {
            using _t = void (PipeReader::*)(QVariant , QVariant );
            if (_t _q_method = &PipeReader::weightFetchedFlat; *reinterpret_cast<_t *>(_a[1]) == _q_method) {
                *result = 5;
                return;
            }
        }
    }else if (_c == QMetaObject::ReadProperty) {
        auto *_t = static_cast<PipeReader *>(_o);
        (void)_t;
        void *_v = _a[0];
        switch (_id) {
        case 0: *reinterpret_cast< QString*>(_v) = _t->str(); break;
        default: break;
        }
    } else if (_c == QMetaObject::WriteProperty) {
        auto *_t = static_cast<PipeReader *>(_o);
        (void)_t;
        void *_v = _a[0];
        switch (_id) {
        case 0: _t->setStr(*reinterpret_cast< QString*>(_v)); break;
        default: break;
        }
    } else if (_c == QMetaObject::ResetProperty) {
    } else if (_c == QMetaObject::BindableProperty) {
    }
}

const QMetaObject *PipeReader::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *PipeReader::qt_metacast(const char *_clname)
{
    if (!_clname) return nullptr;
    if (!strcmp(_clname, qt_meta_stringdata_CLASSPipeReaderENDCLASS.stringdata0))
        return static_cast<void*>(this);
    return QObject::qt_metacast(_clname);
}

int PipeReader::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QObject::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 9)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 9;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 9)
            *reinterpret_cast<QMetaType *>(_a[0]) = QMetaType();
        _id -= 9;
    }else if (_c == QMetaObject::ReadProperty || _c == QMetaObject::WriteProperty
            || _c == QMetaObject::ResetProperty || _c == QMetaObject::BindableProperty
            || _c == QMetaObject::RegisterPropertyMetaType) {
        qt_static_metacall(this, _c, _id, _a);
        _id -= 1;
    }
    return _id;
}

// SIGNAL 0
void PipeReader::startWorker()
{
    QMetaObject::activate(this, &staticMetaObject, 0, nullptr);
}

// SIGNAL 1
void PipeReader::dataFetched(QString _t1)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(std::addressof(_t1))) };
    QMetaObject::activate(this, &staticMetaObject, 1, _a);
}

// SIGNAL 2
void PipeReader::strChanged(QString _t1)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(std::addressof(_t1))) };
    QMetaObject::activate(this, &staticMetaObject, 2, _a);
}

// SIGNAL 3
void PipeReader::initDataFetched(QList<QVariant> _t1)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(std::addressof(_t1))) };
    QMetaObject::activate(this, &staticMetaObject, 3, _a);
}

// SIGNAL 4
void PipeReader::weightDataFetched(QVariant _t1, QVariant _t2, QVariant _t3, QVariant _t4)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(std::addressof(_t1))), const_cast<void*>(reinterpret_cast<const void*>(std::addressof(_t2))), const_cast<void*>(reinterpret_cast<const void*>(std::addressof(_t3))), const_cast<void*>(reinterpret_cast<const void*>(std::addressof(_t4))) };
    QMetaObject::activate(this, &staticMetaObject, 4, _a);
}

// SIGNAL 5
void PipeReader::weightFetchedFlat(QVariant _t1, QVariant _t2)
{
    void *_a[] = { nullptr, const_cast<void*>(reinterpret_cast<const void*>(std::addressof(_t1))), const_cast<void*>(reinterpret_cast<const void*>(std::addressof(_t2))) };
    QMetaObject::activate(this, &staticMetaObject, 5, _a);
}
QT_WARNING_POP
