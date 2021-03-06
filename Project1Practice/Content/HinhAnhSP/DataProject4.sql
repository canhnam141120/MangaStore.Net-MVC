USE [footballManager]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 08/07/2021 4:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerName] [nvarchar](100) NULL,
	[Region] [nvarchar](100) NULL,
	[DateOfBirth] [date] NULL,
	[TeamID] [int] NULL,
	[Position] [varchar](50) NULL,
	[Physical] [float] NULL,
	[Attacking] [float] NULL,
	[Defending] [float] NULL,
	[Speed] [float] NULL,
	[Image] [varchar](max) NULL,
	[isMain] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 08/07/2021 4:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[TeamID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](100) NULL,
	[Region] [nvarchar](100) NULL,
	[Logo] [varchar](max) NULL,
	[Money] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 08/07/2021 4:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[PrivateQuestion] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
	[TeamID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Player] ON 

INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (1, N'Messi', N'Argentine', CAST(N'1987-06-24' AS Date), 1, N'fw', 6, 10, 5, 10, N'm10.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (2, N'Ronaldo', N'Portuguese', CAST(N'1985-02-05' AS Date), 1, N'fw', 10, 9.5, 6, 10, N'cr7.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (3, N'Paul Labile Pogba', N'French', CAST(N'1993-03-15' AS Date), 1, N'mf', 9, 8, 8, 9, N'3ga.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (4, N'Gareth Frank Bale', N'Welsh', CAST(N'1989-07-16' AS Date), 1, N'mf', 8, 8, 7, 10, N'bale.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (5, N'Bruno Fernandes', N'Portuguese', CAST(N'1994-09-08' AS Date), 1, N'fw', 7, 8, 7, 8, N'br.png', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (6, N'Giorgio Chiellini', N'Italya', CAST(N'1984-08-14' AS Date), 1, N'df', 9, 5, 9, 6, N'ch.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (7, N'Philippe Coutinho Correia', N'Brazilian ', CAST(N'1992-06-12' AS Date), 1, N'mf', 9, 9, 5, 8, N'co.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (8, N'Edinson Cavani', N'Uruguayan', CAST(N'1987-02-14' AS Date), 1, N'fw', 8, 8, 5, 8, N'cv.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (9, N'Paulo Dybala', N'Argentine', CAST(N'1993-11-15' AS Date), 1, N'fw', 7, 9, 5, 9, N'Dyjpg.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (10, N'Ryan Giggs', N'Wales', CAST(N'1973-11-29' AS Date), 1, N'fw', 9, 7, 7, 8, N'g.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (11, N'Gerard Piqué', N'Spanish', CAST(N'1987-02-02' AS Date), 1, N'df', 8, 6, 8, 8, N'pq.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (12, N'Marcus Rashford', N'England', CAST(N'1997-10-31' AS Date), 1, N'fw', 8, 8, 7, 10, N'rf.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (13, N'de Jong', N'Netherlands', CAST(N'1997-05-12' AS Date), 1, N'mf', 9, 9, 7, 8, N'sa.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (14, N'Karim Benzema', N'French', CAST(N'1987-12-19' AS Date), 1, N'fw', 9, 9, 7, 10, N'bz.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (15, N'Eden Hazard', N'Belgium', CAST(N'1991-01-07' AS Date), 1, N'fw', 9, 9, 7, 9, N'hz.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (16, N'Toni Kroos', N'Germany', CAST(N'1990-01-04' AS Date), 1, N'mf', 9, 9, 8, 8, N'cr.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (17, N'Marcelo', N'Brazil', CAST(N'1988-05-12' AS Date), 1, N'df', 9, 8, 9, 8, N'lo.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (18, N'Jadon Sancho', N'England', CAST(N'2000-03-25' AS Date), 1, N'fw', 8, 9, 7, 10, N'cho.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (19, N'David de Gea', N'Spanish', CAST(N'1990-11-07' AS Date), 1, N'gk', 9, 5, 9, 5, N'tnk.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (20, N'Kai Havertz', N'Germany', CAST(N'1999-06-11' AS Date), 1, N'mf', 8, 9, 7, 9, N'hv.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (21, N'N''Golo Kanté', N'French', CAST(N'1991-03-29' AS Date), 1, N'mf', 7, 8, 8, 8, N'kan.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (22, N'Manuel Neuer', N'Germany', CAST(N'1986-03-27' AS Date), 1, N'gk', 9, 7, 7, 8, N'neu.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (23, N'Robert Lewandowski', N'Poland', CAST(N'1988-08-21' AS Date), 2, N'fw', 9, 9, 6, 9, N'ld.j[g', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (24, N'Kevin De Bruyne', N'Belgium', CAST(N'1991-06-28' AS Date), 2, N'mf', 9, 9, 8, 9, N'kv.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (26, N'Antoine Griezmann', N'France', CAST(N'1991-03-21' AS Date), 2, N'fw', 8, 8, 8, 8, N'gr.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (27, N'Ansu Fati', N'Guinea-Bissau', CAST(N'2002-10-31' AS Date), 2, N'fw ', 8, 8, 8, 8, N'bu.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (28, N'Dembélé', N'France', CAST(N'1997-05-15' AS Date), 2, N'fw', 9, 8, 8, 9, N'de.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (29, N'Pedri', N'Spain', CAST(N'2002-11-25' AS Date), 2, N'mf', 9, 5, 8, 8, N'fr.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (30, N'Ilaix Moriba', N'Guinea', CAST(N'2003-01-19' AS Date), 2, N'mf', 8, 8, 8, 8, N'z.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (31, N'Sergio Busquets', N'Spain', CAST(N'1988-07-16' AS Date), 2, N'mf', 9, 8, 7, 8, N'qq.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (32, N'Riqui Puig', N'Spain', CAST(N'1999-08-13' AS Date), 2, N'mf', 8, 8, 8, 8, N'pu.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (33, N'Martin Braithwaite', N'Denmark', CAST(N'1991-06-05' AS Date), 2, N'fw', 9, 8, 5, 8, N'bw.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (34, N'Jordi Alba', N'Spain', CAST(N'1989-03-21' AS Date), 2, N'df', 9, 8, 8, 8, N'ab.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (35, N'Samuel Umtiti', N'Cameroon', CAST(N'1993-11-14' AS Date), 2, N'df', 9, 8, 8, 8, N'ut.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (36, N'ter Stegen', N'Germany', CAST(N'1992-04-30' AS Date), 2, N'gk', 9, 5, 5, 8, N'te.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (37, N'Neto', N'Brazil', CAST(N'1989-07-19' AS Date), 2, N'gk', 9, 5, 5, 8, N'ne.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (38, N'Varane', N'France', CAST(N'1993-04-25' AS Date), 2, N'df', 9, 8, 8, 8, N'va.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (39, N'David Alaba', N'Austria', CAST(N'1992-06-24' AS Date), 2, N'df', 9, 8, 6, 7, N'dl.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (40, N'Isco', N'Spain', CAST(N'1992-04-21' AS Date), 2, N'mf', 9, 8, 8, 8, N'is.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (41, N'Luka Modrić', N'Croatia', CAST(N'1985-09-09' AS Date), 2, N'mf', 7, 9, 8, 8, N'MR.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (42, N'Vinícius Júnior', N'Brazil', CAST(N'2000-07-12' AS Date), 2, N'fw', 8, 8, 8, 8, N'vi.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (43, N'Thibaut Courtois', N'Belgium', CAST(N'1992-05-11' AS Date), 2, N'gk', 10, 5, 5, 8, N'cot.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (44, N'Marco Asensio', N'Spain', CAST(N'1996-01-21' AS Date), 2, N'fw', 8, 8, 8, 8, N'as.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (45, N'Nacho', N'Spain', CAST(N'1990-01-18' AS Date), 2, N'df', 8, 6, 8, 8, N'na.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (46, N'Casemiro', N'Brazil', CAST(N'1992-02-23' AS Date), 2, N'df', 8, 8, 8, 8, N'cs.jpg', 0)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (47, N'Federico Valverde', N'Uruguay', CAST(N'1998-07-22' AS Date), 3, N'mf', 8, 8, 8, 8, N'val.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (48, N'Dani Carvajal', N'Spain', CAST(N'1992-01-11' AS Date), 3, N'df', 8, 8, 8, 8, N'rb.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (49, N'Harry Maguire', N'England', CAST(N'1993-03-05' AS Date), 3, N'df', 10, 8, 8, 8, N'mg.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (50, N'Anthony Martial', N'France', CAST(N'1995-12-05' AS Date), 3, N'fw', 9, 8, 8, 8, N'mt.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (51, N'Mason Greenwood', N'England', CAST(N'2001-10-01' AS Date), 3, N'fw', 8, 8, 8, 8, N'grw.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (52, N'Jesse Lingard', N'England', CAST(N'1992-12-15' AS Date), 3, N'mf', 10, 10, 10, 10, N'lg.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (53, N'Donny van de Beek', N'Netherlands', CAST(N'1997-04-18' AS Date), 3, N'mf', 8, 8, 8, 8, N'vb.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (54, N'Tom Heaton', N'England', CAST(N'1986-04-15' AS Date), 3, N'gk', 9, 5, 5, 5, N'to.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (55, N'Juan Mata', N'Spain', CAST(N'1988-04-28' AS Date), 3, N'mf', 8, 8, 8, 8, N'ma.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (56, N'Luke Shaw', N'England', CAST(N'1995-07-12' AS Date), 3, N'df', 9, 8, 8, 8, N'sh.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (57, N'Fred', N'Brazil', CAST(N'1993-03-05' AS Date), 3, N'mf', 8, 8, 8, 8, N'fz.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (58, N'Dean Henderson', N'England', CAST(N'1997-03-12' AS Date), 3, N'gk', 9, 5, 5, 5, N'den.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (59, N'Daniel James', N'England', CAST(N'1997-11-10' AS Date), 3, N'fw', 9, 8, 8, 8, N'ja.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (60, N'Federico Chiesa', N'Italya', CAST(N'1997-10-25' AS Date), 3, N'gw', 8, 8, 8, 8, N'che.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (61, N'Álvaro Morata', N'Spain', CAST(N'1992-10-23' AS Date), 3, N'fw', 9, 0, 0, 9, N'mo.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (62, N'de Ligt', N'Netherlands', CAST(N'1999-08-12' AS Date), 3, N'df', 9, 5, 9, 9, N'san.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (63, N'Leonardo Bonucci', N'Italy', CAST(N'1987-05-01' AS Date), 3, N'df', 9, 7, 9, 9, N'bo.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (64, N'Juan Cuadrado', N'Colombia', CAST(N'1988-05-26' AS Date), 3, N'fw', 9, 8, 8, 8, N'cu.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (65, N'Adrien Rabiot', N'France', CAST(N'1995-04-03' AS Date), 3, N'mf', 8, 8, 8, 8, N'rab.jpg', 1)
INSERT [dbo].[Player] ([PlayerID], [PlayerName], [Region], [DateOfBirth], [TeamID], [Position], [Physical], [Attacking], [Defending], [Speed], [Image], [isMain]) VALUES (66, N'Aaron Ramsey', N'Wales', CAST(N'1990-12-26' AS Date), 3, N'mf', 8, 8, 8, 8, N'rs.jpg', 0)
SET IDENTITY_INSERT [dbo].[Player] OFF
GO
SET IDENTITY_INSERT [dbo].[Team] ON 

INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (1, N'Barcelona', N'Spain', N'baxa.png', 4760000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (2, N'Real Madrid', N'Spain', N'ra.png', 1260000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (3, N'Manchester United', N'England', N'mu.jpg', 3300000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (4, N'Chelsea', N'England', N'cs.png', 3200000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (5, N'Bayern Munich', N'Germany', N'ba.png', 3070000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (6, N'Manchester City', N'England', N'mc.png', 2910000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (7, N'Paris Saint-Germain', N'France', N'pa.png', 1820000000)
INSERT [dbo].[Team] ([TeamID], [TeamName], [Region], [Logo], [Money]) VALUES (8, N'Juve', N'Italya', N'jv.png', 2000000000)
SET IDENTITY_INSERT [dbo].[Team] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (1, N'Carlo Ancelotti', N'sa', N'21312312', N'sa@gmail.com', N'sa', N'sa', 2)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (2, N'Ronald Koeman', N'123', N'123123', N'sb@gmail.com', N'sb', N'sb', 1)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (3, N'Ole', N'123', N'7377218282', N'sc@gmai.com', N'sc', N'sc', 3)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (4, N'Thomas Tuchel', N'123', N'434343', N'sd@gmail.com', N'sd ', N'sd', 4)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (5, N'Hansi Flick', N'123', N'45454545', N'se@gmail.com', N'se', N'se', 5)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (6, N'Pep', N'123', N'3333733737', N'sf@gmial.com', N'sf', N'sf', 6)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (7, N'Mauricio Pochettino', N'123', N'55555', N'mau@gmail.com', N'ss', N'ss', 7)
INSERT [dbo].[User] ([UserID], [UserName], [Password], [Phone], [Email], [PrivateQuestion], [Answer], [TeamID]) VALUES (8, N'Allegri', N'123', N'777777', N'all@gmial.com', N'sls', N'sls', 8)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
