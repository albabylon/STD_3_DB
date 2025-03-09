﻿namespace NonrealationModel
{
    public class NonrealationModel
    {
        // Нереляционные базы данных хранят данные например так:
        // Например, данные могут храниться как:
        // 1 простые пары «ключ–значение» ;
        // 2 JSON;
        // 3 документ;
        // 4 граф.

        // В нереляционных БД объекты хранят скорее в виде иерархических структур
        // Количество атрибутов у таких объектов может быть вообще произвольным.
        // (тут следует понимать, что в реляционных БД это столбец,
        // а в нереляционных — дополнительная строка при описании объекта)

        // КЛЮЧ-ЗНАЧЕНИЕ
        // Обычно в таких системах хранят изображения, кэши объектов, также их используют, когда нужно сделать хорошо масштабируемую БД.
        // Примеры таких хранилищ: Berkeley DB, MemcacheDB[en], Redis, Riak, Amazon DynamoDB.
        // Такие БД в основном используются в приложениях, в которых требуется выполнять поиск на основе одного ключа, а не делать выборку из нескольких таблиц

        // Redis (Remote Dictionary Server) — это нереляционная структура данных в памяти, используемая в качестве базы данных.
        // Работает с данными ключ-значение.
        // Разработана для максимальной скорости set- и get-запросов.
        // Позволяет нам хранить данные в высокоуровневых структурах данных, таких как строки, хэши, списки, наборы.

        // SET ключ значение — записывает строку в ключ. Если ключ до этого был, то он будет перезаписан
        // "SET first 'Hello World"
        // 127.0.0.1:6379> SET first 'Hello World' OK
        // SET second 'GoodBye World' EX 10 - передать время жизни пары
        // Данное значение будет доступно в течение 10 секунд после создания, а потом будет удалено
        // Часто в разных сервисах бывает, что нам присылают код, который действителен в течение, скажем, 40 секунд.

        // Метод GET — это получение значения по ключу. Сейчас попробуем получить ранее созданное первое значение
        // GET first
        // 127.0.0.1:6379> GET first "Hello World"

        // DEL — это удаление значения по ключу. Попробуем удалить первое значение (first)
        // DEL first
        //127.0.0.1:6379> DEL first
        //(integer) 1
        //127.0.0.1:6379> GET first
        //(nil)


        // СЕМЕЙСТВО СТОЛБЦОВ
        // Семейство столбцов можно представить как таблицу, в которой столбцы разделяются на группы или семейства столбцов.

        // Каждое столбчатое хранилище имеет набор логически связанных столбцов, которые обычно извлекаются или управляются как единое целое.
        // Другие данные, которые используются в других процессах, хранятся отдельно в других столбчатых хранилищах.

        // В отличие от БД ключ-значение, где данные упорядочиваются посредством хэш-кодов, в столбчатых БД упорядочивание происходит с помощью самих значений.
        // Ключ строки рассматривается как первичный индекс, и доступ предоставляется по нему.
        // Все столбцы хранятся на диске в одном файле. Это очень удобно при считывании больших объемов данных.


        // ГРАФОВАЯ СУБД
        // Они используются в задачах, где есть большое количество данных со связями.
        // Рёбра графа хранимые и не требуют дополнительных вычислений.
        // Индексы указывают нахождение начальной вершины.

        // Так БД управляют двумя типами данных — узлы и ребра.
        // И как можно понять, узлы представлены как сущности, а рёбра — как связи между ними.
        // Рёбра или грани могут иметь направление, которое указывает на характер связи.
        // Благодаря таким хранилищам очень удобно выполнять запросы на сеть рёбер или узлов.
        // А также достаточно просто анализировать связи между объектами.

        // Обычно большинство таких баз данных имеют свой язык запросов, позволяющий очень легко и быстро обходить даже очень большие графы.

        // ДОКУМЕНТНО-ОРИЕНТИРОВАННАЯ СУБД
        // Документоориентированные СУБД разработаны для хранения иерархических структур данных
        // Данные обычно хранятся как JSON-значение.
        // От ключ-значение отличается тем, что здесь можно искать не только по ключу, но и по данным

        // ПРИМЕР
        // MongoDB — это документо-ориентированная СУБД, которая использует JSON-подобные данные.
    }
}
