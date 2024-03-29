 Программа представляет собой простой чат, реализованный с использованием библиотеки NetMQ для сетевого взаимодействия. Программа состоит из серверной и клиентской частей, которые общаются посредством сетевых сообщений.


1. **Server.cs**:
   - Сервер ожидает сообщения от клиентов.
   - Когда сервер получает сообщение, он обрабатывает его в соответствии с командой (например, регистрация нового пользователя, отправка сообщения, подтверждение получения сообщения).
   - После обработки сообщения сервер отправляет ответ (например, подтверждение получения сообщения) обратно клиенту.



2. **Client.cs**:
   - Клиент ожидает ввода пользователя для отправки сообщений.
   - Когда клиент отправляет сообщение, оно передается серверу.
   - Клиент также ожидает сообщений от сервера и отображает их на экране.


3. **NetMQMessageSource.cs**:
   - Этот класс реализует интерфейс `IMessageSource<T>`, предоставляя методы для отправки и получения сообщений через NetMQ сокеты.
   - В частности, он использует `DealerSocket` для отправки и получения сообщений между сервером и клиентами.



4. **Program.cs**:
   - В методе `Main` определяется, запускается ли программа в режиме сервера или клиента в зависимости от аргументов командной строки.
   - Если программа запускается без аргументов, она запускает сервер.
   - Если программа запускается с тремя аргументами (никнейм клиента, IP адрес сервера, порт сервера), она запускает клиентскую часть для подключения к указанному серверу.
 
 
