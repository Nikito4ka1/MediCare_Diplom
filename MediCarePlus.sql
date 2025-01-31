USE [MediCarePlus]
GO
/****** Object:  Table [dbo].[Category_insurance]    Script Date: 10.06.2024 11:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_insurance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_category_insurance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 10.06.2024 11:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[patronymic] [nvarchar](50) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[phone] [int] NOT NULL,
	[email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 10.06.2024 11:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client_id] [int] NOT NULL,
	[medical_insurance_id] [int] NOT NULL,
	[date_start] [date] NOT NULL,
	[date_end] [date] NOT NULL,
 CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medical_insurance]    Script Date: 10.06.2024 11:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medical_insurance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[price] [money] NOT NULL,
	[category_id] [int] NOT NULL,
 CONSTRAINT [PK_medical_insurance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10.06.2024 11:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](20) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[patronymic] [nvarchar](50) NOT NULL,
	[role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category_insurance] ON 

INSERT [dbo].[Category_insurance] ([id], [name]) VALUES (1, N'Медицинское страхование (ДМС) для взрослых')
INSERT [dbo].[Category_insurance] ([id], [name]) VALUES (2, N'Медицинское страхование (ДМС) для путешествий')
INSERT [dbo].[Category_insurance] ([id], [name]) VALUES (3, N'Детское медицинское страхование (ДМС)')
INSERT [dbo].[Category_insurance] ([id], [name]) VALUES (4, N'Беременность и роды: медицинское страхование')
INSERT [dbo].[Category_insurance] ([id], [name]) VALUES (5, N'Стоматологическое медицинское страхование (ДМС)')
SET IDENTITY_INSERT [dbo].[Category_insurance] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (1, N'Артур', N'Иванов', N'Андреевич', N'ул. Пушкина, д. 11', 897799889, N'ivanov@example.com')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (2, N'Петр', N'Петров', N'Иванович', N'пр. Ленина, д. 20', 986542107, N'petrov@example.com')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (3, N'Мария', N'Сидорова', N'Федоровна', N'пл. Революции, д. 5', 987465584, N'sidorova@example.com')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (4, N'Алексей', N'Юсупов', N'Олегович', N'г. Москва ул. Первомайская д. 23', 98463721, N'aleksey2361@gmail.com')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (5, N'Никита', N'Яблоков', N'Андреевич', N'г. Коломна ул. Совецкая д. 2', 96587843, N'nikitaapple@gmail.com')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (6, N'Антон', N'Грушин', N'Васильевич', N'г. Луховицы ул. Зеленая д. 4', 95687467, N'bvcgwvfy457@yandex.ru')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (7, N'Олег', N'Олегов', N'Олегович', N'г. Екатеренбург ул. Голубая д. 2', 976458234, N'olegolegov@yandex.ru')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (8, N'Анна', N'Одуванчикова', N'Олеговна', N'г. Коломна ул. Ленинская д. 43', 98532651, N'annaoduv7465@gmail.com')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (9, N'Люда', N'Низкова', N'Андреевна', N'г. Москва ул. Котельники д. 5', 985466322, N'lilicbhdw542@yandex.ru')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (10, N'Алексей', N'Юсупов', N'Александрович', N'с. Акатьево ул. Юбилейная д. 17', 95872364, N'GGnagibator76431@gmail.com')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (11, N'Никита', N'Петухов', N'Олегович', N'г. Луховицы ул. Книжная д. 32', 9564764, N'nikita62373@gmail.com')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (12, N'Василий ', N'Антонов', N'Антонович', N'г. Зарайск ул. Меренцкова д. 6', 96736612, N'vasiliud23412@yandex.ru')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (13, N'Руслан', N'Лебедев', N'Антонович', N'г. Тула ул. Совецкая д. 98', 98873521, N'Rusjdyeb323@yandex.ru')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (14, N'Антон', N'Домовой', N'Дмитревич', N'г. Москва ул. Совецкая д. 43', 984722534, N'ggusjdyc8573@gmail.com')
INSERT [dbo].[Clients] ([id], [name], [surname], [patronymic], [address], [phone], [email]) VALUES (15, N'Татьяна', N'Гусева', N'Станиславовна', N'с. Чулки-Соколово ул. Центральная д. 1', 984347, N'tahfsyuhn@gmail.com')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Contracts] ON 

INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (1, 1, 1, CAST(N'2024-05-26' AS Date), CAST(N'2025-05-27' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (2, 2, 2, CAST(N'2024-03-22' AS Date), CAST(N'2025-05-23' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (3, 3, 4, CAST(N'2024-04-21' AS Date), CAST(N'2025-04-22' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (4, 4, 2, CAST(N'2024-01-01' AS Date), CAST(N'2025-01-15' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (5, 5, 2, CAST(N'2024-01-01' AS Date), CAST(N'2025-07-09' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (6, 6, 1, CAST(N'2024-02-09' AS Date), CAST(N'2025-06-13' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (7, 7, 5, CAST(N'2024-03-15' AS Date), CAST(N'2025-12-12' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (8, 8, 5, CAST(N'2024-05-31' AS Date), CAST(N'2025-11-30' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (9, 9, 2, CAST(N'2024-06-26' AS Date), CAST(N'2024-12-31' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (10, 10, 3, CAST(N'2024-07-11' AS Date), CAST(N'2025-11-14' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (11, 11, 5, CAST(N'2024-08-17' AS Date), CAST(N'2025-12-19' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (12, 12, 1, CAST(N'2024-09-20' AS Date), CAST(N'2025-07-31' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (13, 13, 5, CAST(N'2024-10-26' AS Date), CAST(N'2024-12-30' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (14, 14, 1, CAST(N'2024-11-22' AS Date), CAST(N'2025-12-26' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (15, 14, 3, CAST(N'2024-12-31' AS Date), CAST(N'2025-12-30' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (16, 15, 5, CAST(N'2024-06-03' AS Date), CAST(N'2025-12-31' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (19, 11, 3, CAST(N'2023-03-09' AS Date), CAST(N'2024-07-12' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (20, 7, 3, CAST(N'2023-07-15' AS Date), CAST(N'2024-07-13' AS Date))
INSERT [dbo].[Contracts] ([id], [client_id], [medical_insurance_id], [date_start], [date_end]) VALUES (21, 11, 2, CAST(N'2023-12-08' AS Date), CAST(N'2024-12-21' AS Date))
SET IDENTITY_INSERT [dbo].[Contracts] OFF
GO
SET IDENTITY_INSERT [dbo].[Medical_insurance] ON 

INSERT [dbo].[Medical_insurance] ([id], [name], [description], [price], [category_id]) VALUES (1, N'Добровольное медицинское страхование на случай болезни и несчастного случая', N'Этот вид страхования обычно покрывает расходы на лечение при различных заболеваниях и несчастных случаях', 12000.0000, 1)
INSERT [dbo].[Medical_insurance] ([id], [name], [description], [price], [category_id]) VALUES (2, N'Добровольное медицинское страхование для путешествий и выездов за границу', N'Этот вид страхования обеспечивает медицинскую помощь за границей, включая консультации специалистов, госпитализацию, лечебные процедуры и др', 5000.0000, 2)
INSERT [dbo].[Medical_insurance] ([id], [name], [description], [price], [category_id]) VALUES (3, N'Добровольное медицинское страхование для детей', N'Это страхование предоставляет медицинское обслуживание для детей, включая консультации педиатра, неотложную помощь, лечение заболеваний', 6000.0000, 3)
INSERT [dbo].[Medical_insurance] ([id], [name], [description], [price], [category_id]) VALUES (4, N'Добровольное медицинское страхование для беременных женщин', N'Этот вид страхования покрывает медицинское сопровождение беременности, роды и послеродовый период', 8000.0000, 4)
INSERT [dbo].[Medical_insurance] ([id], [name], [description], [price], [category_id]) VALUES (5, N'Добровольное стоматологическое страхование', N'Эта страховка покрывает расходы на стоматологические услуги, включая профилактику, лечение кариеса, установку протезов и др', 10000.0000, 5)
SET IDENTITY_INSERT [dbo].[Medical_insurance] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [login], [password], [name], [surname], [patronymic], [role]) VALUES (1, N'l', N'p', N'Василий', N'Лебедев', N'Андреевич', N'Агент отдела медицинского страхования')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_Clients] FOREIGN KEY([client_id])
REFERENCES [dbo].[Clients] ([id])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_Clients]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_Medical_insurance] FOREIGN KEY([medical_insurance_id])
REFERENCES [dbo].[Medical_insurance] ([id])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_Medical_insurance]
GO
ALTER TABLE [dbo].[Medical_insurance]  WITH CHECK ADD  CONSTRAINT [FK_Medical_insurance_Category_insurance] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category_insurance] ([id])
GO
ALTER TABLE [dbo].[Medical_insurance] CHECK CONSTRAINT [FK_Medical_insurance_Category_insurance]
GO
