CREATE TABLE [dbo].[Заявки]
(
	[Номер_заявки] INT NOT NULL PRIMARY KEY, 
    [Дата_оформления] DATE NULL, 
    [Заявитель] VARCHAR(70) NULL, 
    [Контактный_телефон] VARCHAR(50) NULL, 
    [Электронная почта] VARCHAR(150) NULL, 
    [Адрес] VARCHAR(50) NULL, 
    [Организация] VARCHAR(50) NULL, 
    [Тип_заявки] VARCHAR(50) NULL, 
    [Жалоба] VARCHAR(1000) NULL, 
    [Дата_завершения] DATE NULL, 
    [Статус] VARCHAR(50) NULL, 
    [Результат_заявки] VARCHAR(1000) NULL
)
