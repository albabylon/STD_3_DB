namespace RelationModel
{
    public class RelationModel
    {
        // Реляционная база данных — это набор данных с предопределенными связями между ними.
        // Эти данные представлены в виде таблиц, состоящих из столбцов и строк.
        // В каждом столбце таблицы хранится определенный тип данных, в каждой ячейке — значение.
        // Каждая строка в такой таблице предоставляет набор значений, относящихся к одному объекту

        // Реляционная модель предполагает логическую структуру данных: таблицы, представления и индексы
        // Соответственно, под логической структурой понимаются таблицы, под физической — файлы
        // Такое разделение дает возможность администраторам управлять физической системой хранения, не меняя данных, содержащихся в логической структуре

        // Разработчики уяснили, что таблицы являются ключевым преимуществом реляционных баз данных,
        // так как обеспечивают интуитивно понятный, эффективный и гибкий способ хранения структурированной информации и получения к ней доступа.

        // Также мы можем отслеживать добавляемые данные для обеспечения структурной целостности.
        // Например, атрибут UNIQUE говорит о том, что значения в столбце не могут повторяться.





        // MSSQL
        // sqlcmd -Q "CREATE DATABASE testdb" - создание БД
        // sqlcmd -S .\SQLEXPRESS - если ошибка и MSSQL SERVER установлен более 1 раза

        // sqlcmd -d testdb -Q "CREATE TABLE testtable (id INT IDENTITY PRIMARY KEY,title VARCHAR(255) NOT NULL,description TEXT)"
        // Где:
        //id — это поле, в котором мы храним уникальный идентификатор для каждой созданной строки в таблице;
        //INT говорит о том, что этот идентификатор — число;
        //IDENTITY — то, что с каждым новым добавлением новой строки он будет возрастать на 1;
        //PRIMARY KEY показывает, что это поле — первичный ключ, но об этом в следующем юните;
        //title — собственно название второго столбца;
        //VARCHAR(255) значит, что данное поле состоит из символов не более 255 штук;
        //NOT NULL — поле должно быть обязательно заполнено при вставке в таблицу, иначе запрос не пройдёт;
        //description — название третьего столбца;
        //столбец TEXT в большинстве случаев может рассматриваться как столбец VARCHAR неограниченного размера.

        // Добавление данных:
        // sqlcmd -d testdb -Q "insert testtable(title,description) VALUES ('test1' ,'test2');"
        // sqlcmd -d testdb -Q "insert testtable(title,description) VALUES ('test1111' ,'test22222');"

        // Смотрим данные:
        // sqlcmd -d testdb -Q "select * from testtable"

        // UNIQUE гарантирует, что все значения в столбце различаются
        // Уникальные и первичные ограничения предоставляют гарантию уникальности для столбца или набора столбцов.
        // Ограничение первичного ключа автоматически имеет уникальное ограничение.
        // Однако, можно иметь много уникальных ограничений для каждой таблицы, но только одно ограничение первичного ключа для каждой таблицы.

        // sqlcmd -d testdb -Q "CREATE TABLE Persons (ID int NOT NULL,LastName varchar(255) NOT NULL,FirstName varchar(255),Age int,UNIQUE (ID));"


        // UPDATE - меняет данные в таблице
        // SET - какие именно столбцы модифицировать и какие значения
        // WHERE - какие строки подлежат измененнию

        // sqlcmd -d testdb -Q "UPDATE testtable SET title='REALTEST' where id =2;"





        // ПЕРВИЧНЫЙ КЛЮЧ
        // Если в таблице каждая строка однозначно определяется одним или несколькими уникальными значениями,
        // которые принимают её ячейки из определенного подмножества столбцов, то говорят, что у таблицы есть первичный ключ.
        // Первичный ключ — это подмножество столбцов, которое уникально идентифицирует строку.
        // Часто в качестве первичного ключа берут просто ID объекта, например, ID пользователя или ID покупки.

        // В MSSQL первичный ключ — это одно поле или несколько полей, которые определяют уникальность записи
        // Ячейки, являющиеся частью первичного ключа, не могут содержать значение NULL
        // Кстати, в каждой таблице может быть только один первичный ключ

        // Задать первичный ключ:
        // 1. Первый способ (поле ID):
        // sqlcmd -d testdb -Q "CREATE TABLE developers(ID INT NOT NULL IDENTITY PRIMARY KEY, NAME VARCHAR (100) NOT NULL, SPECIALTY VARCHAR(100) NOT NULL, SALARY INT NOT NULL);"
        // 2. Второй способ (поле ID):
        // sqlcmd -d testdb -Q "CREATE TABLE developers(ID INT NOT NULL, NAME VARCHAR (100) NOT NULL, SPECIALTY VARCHAR(100) NOT NULL, SALARY INT NOT NULL, PRIMARY KEY (ID));"

        // Для применения в существующей таблице:
        // sqlcmd -d testdb -Q "ALTER TABLE developers ADD PRIMARY KEY (ID);"



        // ВНЕШНИЙ КЛЮЧ
        // Внешний ключ SQL — это ключ, используемый для объединения двух таблиц. Иногда его также называют ссылочным ключом.
        // Внешний ключ — это столбец или набор столбцов, которые соответствуют первичному ключу в другой таблице.

        // создаем 2 таблицы и связываем внешний ключ CUSTOMER_ID таблицы ORDERS с первичным ключом ID таблицы CUSTOMERS:
        // sqlcmd -d testdb -Q "CREATE TABLE CUSTOMERS(ID INT NOT NULL, NAME VARCHAR(20) NOT NULL, AGE INT NOT NULL, ADDRESS CHAR (25),SALARY DECIMAL (18, 2),PRIMARY KEY (ID));"
        // sqlcmd -d testdb -Q "CREATE TABLE ORDERS (ID INT NOT NULL,DATE DATETIME,CUSTOMER_ID INT references CUSTOMERS(ID),AMOUNT float,PRIMARY KEY (ID));"

        // Если таблица ORDERS уже создана и для неё ещё не установлен внешний ключ:
        // sqlcmd -d testdb -Q "ALTER TABLE ORDERS ADD FOREIGN KEY (Customer_ID) REFERENCES CUSTOMERS (ID);"


        // «Покупатели покупают продукты» указывает, что существует связь между сущностью «покупатели» и сущностью «продукты». - 2ая связь
        // В утверждении «сотрудники продают товары покупателям» - 3ая связь
        // Виды связи:
        // 1 Один к одному
        // 2 Один ко многим
        // 3 Многие ко многим

        // ER- диаграмма - один из самых удобных способов представления сущностей и связей
        // Прямоугольник - сущность, атрибуты — эллипсы, отношения — ромбы


        // Пример: «сотрудники компании–автомобили компании» - Один к одному
        // Создаем БД:
        // sqlcmd -Q "create database onetoone;"

        // Создаем таблицу сотрудников компании:
        // sqlcmd -d onetoone -Q "create table employees(ID INT IDENTITY PRIMARY KEY,NAME VARCHAR(80) NOT NULL,SURNAME VARCHAR(80) NOT NULL,PATRONYMIC VARCHAR(80),CITY VARCHAR(40),ADDRESS VARCHAR(150),NUMBER VARCHAR(13), CAR_ID INT NOT NULL);"

        // Добавим вторую таблицу с содержанием автомобилей сотрудников:
        // sqlcmd -d onetoone -Q "create table cars(CAR_ID INT IDENTITY PRIMARY KEY,YEAR VARCHAR(4), MODEL VARCHAR(20),MARK VARCHAR(20));"

        // Последнее поле CAR_ID сделаем внешним ключом.
        // Обычно внешний ключ одной таблицы должен ссылаться на первичный ключ другой.

        // Самое время связать таблицы внешним ключом. Но перед этим на всякий случай сделаем поле CAR_ID в таблице employees уникальным:
        // sqlcmd -d onetoone -Q "ALTER TABLE employees ADD UNIQUE(CAR_ID);"

        // Запрос на добавление внешнего ключа:
        // sqlcmd -d onetoone -Q "ALTER TABLE employees ADD FOREIGN KEY(CAR_ID) REFERENCES cars(CAR_ID);"

        // Заполним таблицы тестовыми данными:
        // sqlcmd -d onetoone -Q "insert cars(YEAR, MODEL, MARK) VALUES ('1989','GAZ','2400'),('2012','BMW','740d xDrive'),('1993','daimler benz','w124'),('2020','Honda','Civic');"
        // Смотрим: sqlcmd -d onetoone -q "select * from cars;"

        // Заполним сотрудниками:
        // sqlcmd -d onetoone -Q "insert employees(NAME,SURNAME,PATRONYMIC,CITY,ADDRESS,NUMBER,CAR_ID) VALUES('Ivan','Ivanov','Ivanovi4','Moscow','Mira h.1 fl.3','+79008001010','3'),('Oleg','Morkovkin','Yrjevich','Mytishchi','pr. krasnoy armii 212/3','+79001008080','2');"
        // При попытке добавить пользователя с уже занятой машиной, получим ошибку


        // Чтобы посмотреть связь между двумя таблицами:
        // sqlcmd -d onetoone -Q "select NAME,SURNAME,MODEL from employees,cars where employees.CAR_ID=cars.CAR_ID;"

        // На данном примере мы разобрались, как строить связь «один к одному».
        // Из-за такой связи достаточно тяжело становится добавлять людей без машины, так как это вызовет ошибку.



        // Пример: «человеек–номера телефонов» - Один ко многим
        // Связь «один ко многим» в реляционных базах данных реализуется тогда, когда объекту А может принадлежать
        // или же соответствовать несколько объектов Б, но объекту Б может соответствовать только один объект А.

        // Создадим БД:
        // sqlcmd -Q "create database onetomany;"

        // Создадим карточку клиента:
        // sqlcmd -d onetomany -Q "create table client(ID INT IDENTITY PRIMARY KEY,FIO varchar(255) NOT NULL);"

        // Создадим справочник:
        // sqlcmd -d onetomany -Q "create table phone_num(ID INT IDENTITY PRIMARY KEY,NUMBER VARCHAR(13) NOT NULL,USER_ID INT NOT NULL);"

        // Зададим внешний ключ
        // sqlcmd -d onetomany -Q "ALTER TABLE phone_num ADD FOREIGN KEY(USER_ID) REFERENCES client(ID);"

        // Заполняем тестовыми данными
        // sqlcmd -d onetomany -Q "insert client(FIO) VALUES ('Ivanov Ivan Ivanovich'),('Petrov Petr Petrovich'),('Testerov Tester Testerovich'),('Olgerd');"
        // sqlcmd -d onetomany -Q "insert phone_num(NUMBER,USER_ID) VALUES ('89008001010','1'),('89008002020','1'),('89008003030','1');"
        // sqlcmd -d onetomany -Q "insert phone_num(NUMBER,USER_ID) VALUES ('89118111111','2'),('8118111235','2');"
        // sqlcmd -d onetomany -Q "insert phone_num(NUMBER,USER_ID) VALUES ('+790CALLME95','3');"

        // Смотрим
        // sqlcmd -d onetomany -Q "select * from client;"
        // sqlcmd -d onetomany -Q "select * from phone_num;"

        // С помощью запроса посмотрим на весь справочник целиком
        // Данная конструкция NUMBER as 'Номер телефона' чисто визуальная и нужна для улучшения восприятия информации пользователем.
        // sqlcmd -d onetomany -Q "select NUMBER as 'Номер телефона',FIO as 'ФИО' from phone_num,client where USER_ID=client.ID;"


        // Пример: «книжный магазин» - Многие ко многим
        // Связь «многие ко многим» реализуется в том случае, когда нескольким объектам из таблицы А может соответствовать несколько объектов из таблицы Б,
        // и в тоже время, нескольким объектам из таблицы Б соответствует несколько объектов из таблицы А и организовывается посредством связывающей таблицы.

        // Создаем БД
        // sqlcmd -Q "create database manytomany;"

        // Создаем таблицу с книгами и таблицу с авторами:
        // sqlcmd -d manytomany -Q "create table books(ID_book INT IDENTITY PRIMARY KEY,title varchar(255) NOT NULL ,price float NOT NULL, count int default 0);"
        // sqlcmd -d manytomany -Q "create table author(ID_author INT IDENTITY PRIMARY KEY,FIO varchar(255) NOT NULL ,ADDRESS varchar(255),phone varchar(13),city varchar(20),contry varchar(20),borndate date NOT NULL, deathdate date);"

        // Создаём результирующую таблицу:
        // sqlcmd -d manytomany -Q "create table result_table(author_ID int not null,book_ID int not null,PRIMARY KEY(author_ID,book_ID));"
        // Первичным ключом в результирующей таблице являются оба поля. Так как один и тот же автор не может написать две одинаковые книги.

        // Заполним таблицы тестовыми данными:
        // sqlcmd -d manytomany -Q "insert into books(title,price,count) values ('Как помыться в московском метро?','10','6'),('Сборник случайных рассказов ТОМ 1',15,5),('Сборник случайных рассказов ТОМ 2',15.5,6),('Сборник случайных рассказов ТОМ 3',16,2);"
        // sqlcmd -d manytomany -Q "insert into books(title,price,count) values ('Пустая книга','11.5','0'),('Явно дорогая книга',250,2),('Явно дешевая книга',0.56,15),('Явно неявная книга',10,10);"

        // Смотрим
        // sqlcmd -d manytomany -Q "select title as 'Название книги', price as 'Стоимость', count as 'Количество' from books;"

        // Заполним тестовые данные для авторов книг
        // sqlcmd -d manytomany -Q "insert author(FIO,ADDRESS,phone,city,contry,borndate,deathdate) VALUES ('Иванов Иван Иванович','ул.Кого то там д.15 кв.3','+79008001010','Москва','Россия','1985-12-23',NULL);"
        // sqlcmd -d manytomany -Q "insert author(FIO,ADDRESS,phone,city,contry,borndate,deathdate) VALUES ('Петров Петр Петрович','проспект важного маршала д.5/2а кв.22','+79018200010','Москва','Россия','1955-10-23','2015-03-15');"
        // sqlcmd -d manytomany -Q "insert author(FIO,ADDRESS,phone,city,contry,borndate,deathdate) VALUES ('Сидоров Сидр Сидорович','Не важно',NULL,'Москва','СССР','1922-02-01','1991-03-05');"
        // sqlcmd -d manytomany -Q "insert author(FIO,ADDRESS,phone,city,contry,borndate,deathdate) VALUES ('Коньков Олег Игоревич','Не важно',NULL,'Киев','Украина','1989-10-28',NULL);"

        // Смотрим
        // sqlcmd -d manytomany -Q "Select ID_author,FIO,city,contry from author;"

        // Создадим взаимосвязь между авторами и книгами:
        // sqlcmd -d manytomany -Q "insert result_table(book_id,author_id) values (1,1),(2,2),(2,3),(3,2),(4,5),(5,5),(6,5);"

        // Результирующая таблица выглядит не очень понятно (но простыми запросами мы можем выяснить, кто автор какой книги, или вычислить общую стоимость книг на складе)
        // sqlcmd -d manytomany -Q "select * from result_table;"

        // Пример кода для того чтобы понять, кто написал какую книгу и кто с кем был в соавторстве:
        // sqlcmd -d manytomany -Q "select FIO,title from author,books,result_table where author_ID=ID_author and book_ID=ID_book Order by title;"

        // Пишем запрос, чтобы найти книги ещё живых авторов:
        // sqlcmd -d manytomany -Q "select FIO,title from author,books,result_table where author_ID=ID_author and book_ID=ID_book and deathdate is null;"

        // Узнаем, какие книги написали авторы-москвичи:
        // sqlcmd -d manytomany -Q "select FIO,title from author,books,result_table where author_ID=ID_author and book_ID=ID_book and city='Москва';"
    }
}
