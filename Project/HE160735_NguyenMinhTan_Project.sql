CREATE DATABASE [HE160735_NguyenMinhTan_Project]
USE [HE160735_NguyenMinhTan_Project]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 7/26/2023 10:04:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Book_id] [int] IDENTITY(1,1) NOT NULL,
	[User_id] [int] NOT NULL,
	[Book_date] [date] NOT NULL,
	[Book_time] [nvarchar](150) NOT NULL,
	[Number_of_people] [int] NOT NULL,
	[Note] [nvarchar](150) NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Phone] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/26/2023 10:04:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Category_id] [int] IDENTITY(1,1) NOT NULL,
	[Category_name] [nvarchar](150) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 7/26/2023 10:04:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[Food_id] [int] IDENTITY(1,1) NOT NULL,
	[Food_name] [nvarchar](150) NOT NULL,
	[Food_description] [nvarchar](150) NOT NULL,
	[Food_price] [float] NOT NULL,
	[Food_category] [int] NOT NULL,
	[Food_image] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[Food_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/26/2023 10:04:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[User_id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[Phone] [nvarchar](150) NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (1, 380008, CAST(N'2023-07-05' AS Date), N'9h', 4, N'birthday', N'tan', N'tan@gmail.com', N'0986114510')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (2, 760920, CAST(N'2023-07-06' AS Date), N'8h', 3, N'avc', N'tan', N'tan@gmail.com', N'1234')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (3, 307786, CAST(N'2023-06-30' AS Date), N'8h30', 3, N'123', N'tan', N'tan123@gmail.com', N'13223')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (5, 256403, CAST(N'2023-07-06' AS Date), N'2h', 4, N'123123', N'tan', N'tan@gmail.com', N'123123')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (6, 582777, CAST(N'2023-07-08' AS Date), N'7h', 3, N'123', N'tan', N'tan@gmail.com', N'123123123')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (7, 815178, CAST(N'2023-06-30' AS Date), N'3', 2, N'213', N'tan', N'tan@gmail.com', N'123123')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (8, 189814, CAST(N'2023-07-06' AS Date), N'8h', 3, N'123', N'tan', N'Tan@gmail.com', N'12312')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (10, 726238, CAST(N'2023-06-29' AS Date), N'6h', 2, N'123', N'tan', N'123@gmaio.com', N'123')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (11, 228588, CAST(N'2023-06-29' AS Date), N'6h', 2, N'123', N'tan', N'123@gmaio.com', N'123')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (12, 333852, CAST(N'2023-07-07' AS Date), N'8h', 2, N'123', N'tan', N'tan@gmail.com', N'123')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (13, 843354, CAST(N'2023-07-15' AS Date), N'6', 2, N'123', N'tan', N'tan@gmail.com', N'123')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (14, 397825, CAST(N'2023-07-15' AS Date), N'6', 2, N'123', N'tan', N'tan@gmail.com', N'123')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (15, 306245, CAST(N'2023-07-15' AS Date), N'6', 2, N'123', N'tan', N'tan@gmail.com', N'123')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (16, 175428, CAST(N'2023-07-14' AS Date), N'123213', 2, N'123', N'tan', N'tan@gmail.com', N'1231')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (18, 2, CAST(N'2023-07-20' AS Date), N'5h', 2, N'123', N'tan', N'tan@gmail.com', N'123')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (1004, 2, CAST(N'2023-07-24' AS Date), N'9h', 4, N'birth day party', N'Nguyen minh tan', N'Tan@gmail.com', N'0986114510')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (1005, 2, CAST(N'2023-08-01' AS Date), N'7h', 2, N'123', N'tan222', N'tan222@gmail.com', N'12345')
GO
INSERT [dbo].[Book] ([Book_id], [User_id], [Book_date], [Book_time], [Number_of_people], [Note], [Name], [Email], [Phone]) VALUES (2004, 2007, CAST(N'2023-07-27' AS Date), N'7h30', 4, N'birthday party', N'tan', N'tan@gmail.com', N'123')
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([Category_id], [Category_name]) VALUES (1, N'Starter')
GO
INSERT [dbo].[Category] ([Category_id], [Category_name]) VALUES (2, N'Appetizer')
GO
INSERT [dbo].[Category] ([Category_id], [Category_name]) VALUES (3, N'MainDishes')
GO
INSERT [dbo].[Category] ([Category_id], [Category_name]) VALUES (4, N'Dessert')
GO
INSERT [dbo].[Category] ([Category_id], [Category_name]) VALUES (7, N'Khai vi')
GO
INSERT [dbo].[Category] ([Category_id], [Category_name]) VALUES (11, N'Mon chinh')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (6, N'Thịt nguội bát bửuuuuu', N'Chả lụa, giò thủ, Jambon, nem, chả bò, thịt xá xíuuuuuuuu', 444444, 1, N'https://cdn.tgdd.vn/Files/2022/04/04/1423782/goi-y-8-mon-nguoi-khai-vi-cho-nhung-buoi-tiec-hoi-hop-voi-gia-dinh-202204040915196807.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (8, N'Càng cua bách hoa', N'Kèm thịt heo, gà xay nhuyễn', 70000, 1, N'https://cdn.tgdd.vn/Files/2022/04/04/1423782/goi-y-8-mon-nguoi-khai-vi-cho-nhung-buoi-tiec-hoi-hop-voi-gia-dinh-202204040917588586.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (10, N'Gỏi bưởi tôm mực', N'Bưởi, tôm, mực', 60000, 1, N'https://cdn.tgdd.vn/Files/2022/04/04/1423782/goi-y-8-mon-nguoi-khai-vi-cho-nhung-buoi-tiec-hoi-hop-voi-gia-dinh-202204040921553201.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (12, N'Gỏi miến trộn tôm thịt', N'Ăn cùng rau củ, bánh phồng cá', 60000, 1, N'https://cdn.tgdd.vn/Files/2022/04/04/1423782/goi-y-8-mon-nguoi-khai-vi-cho-nhung-buoi-tiec-hoi-hop-voi-gia-dinh-202204040922172703.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (13, N'Thịt ba chỉ nướng sa tế', N'Màu sắc bắt mắt cùng mùi thơm quyến rũ', 60000, 2, N'https://cdn.tgdd.vn/2020/10/CookRecipe/Avatar/thit-nuong-sa-te-bang-noi-chien-khong-dau-thumbnail-1.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (14, N'Thịt bò cuốn nấm kim châm', N'Thịt bò thơm béo, mềm mềm kết hợp cùng nấm kim châm giòn giòn', 60000, 2, N'https://cdn.tgdd.vn/2021/09/CookRecipe/Avatar/ba-chi-bo-cuon-nam-kim-cham-nuong-thumbnail.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (15, N'Tôm nướng muối ớt', N'Một chút cay của ớt, một chút mằn mặn của muối', 100000, 2, N'https://cdn.tgdd.vn/2021/12/CookRecipe/Avatar/tom-nuong-muoi-ot-thumbnail.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (16, N'Thịt bò nướng tảng ăn kèm khoai tây nướng', N'Mang phong cách Âu thơm ngon, lạ miệng', 200000, 2, N'https://cdn.tgdd.vn/2021/02/CookRecipe/Avatar/thit-bo-nuong-tang-thumbnail-1.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (17, N'Bạch tuộc nướng sa tế', N'Thấm gia vị cay cay mặn mặn', 150000, 2, N'https://cdn.tgdd.vn/2020/07/CookRecipe/Avatar/bach-tuoc-nuong-sa-te-thumbnail.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (18, N'Đùi gà nướng bơ tỏi', N'Thơm nức đầy cuốn hút của bơ, tỏi, thịt gà', 150000, 2, N'https://cdn.tgdd.vn/2020/06/CookRecipe/Avatar/cach-lam-dui-ga-nuong-bo-toi-thumbnail.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (19, N'Thịt xiên nướng kim tiền kèm đậu bắp', N'Ngọt, thấm vị đậm đà', 100000, 2, N'https://cdn.tgdd.vn/2021/01/CookRecipe/Avatar/thit-nuong-kim-tien-thumbnail-1.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (20, N'Bò cuốn lá lốt', N'Thơm mùi lá lốt, sả, ớt', 200000, 2, N'https://cdn.tgdd.vn/2021/04/CookRecipe/Avatar/bo-nuong-la-lot-thumbnail.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (22, N'Lẩu thái', N'Có màu đỏ vô cùng đẹp mắt của gấc, thơm nức mùi chanh, sả, riềng vị hòa cùng vị ngọt tự nhiên từ nước hầm xương gà, tất cả vô cùng hài hòa, đậm vị.', 499000, 3, N'https://www.cet.edu.vn/wp-content/uploads/2018/03/hinh-anh-lau-thai-chua-cay.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (24, N'Lẩu bò', N'Thơm lừng mùi sả, ăn vào có vị ấm của gừng, cảm nhận được độ ngọt thịt và xương bò, dai dai của nạm bò, ăn kèm bò viên, đậu hũ, mướp, rau xanh,', 499000, 3, N'https://beptruong.edu.vn/wp-content/uploads/2021/03/lau-bo.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (25, N'Lẩu gà', N'Nồi nước lẩu gà càng thêm dậy mùi, ngoài ra với vị ngọt tự nhiên của thịt gà ăn kèm với nấm, hay rau và cá, hải sản khác đều ngon nức mũi.', 499000, 3, N'https://cdn.tgdd.vn/Files/2021/08/09/1373931/cach-nau-lau-ga-la-que-thom-lung-cuc-hap-dan-tai-nha-202108090309091863.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (26, N'Lẩu cá', N'Nước dùng của nồi lẩu cá thì đậm đà gia vị, chua chua cay cay, thơm lừng sả, riềng, ăn kèm với bún, rau, cá viên,..', 499000, 3, N'https://cdn.pastaxi-manager.onepas.vn/content/uploads/articles/0000-phuong-mon%20ngon&%20con%20thuc/9.%20lau%20ca/A1.Lau-ca-thom-ngon-bo-duong.png')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (29, N'Lẩu hải sản', N'Vị ngọt tự nhiên của cua đồng và nấm ăn vào vô cùng thanh mát, kích thích vị giác.

Thịt cua săn chắc hòa cùng vị béo béo của gạch cua', 499000, 3, N'https://cdn.tgdd.vn/Files/2021/02/25/1330480/tong-hop-5-cach-nau-lau-hai-san-thom-ngon-tai-nha-202206031654454333.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (30, N'Lẩu mắm', N'Vị đậm đà của mắm, của gia vị ăn kèm rau và bún thì lại vô cùng hòa quyện.', 499000, 3, N'https://cdn.tgdd.vn/Files/2021/12/08/1403295/tong-hop-cac-mon-lau-ngon-de-lam-ma-ban-khong-nen-bo-qua-202112082047010371.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (31, N'Lẩu dê', N'Lẩu dê có hương vị thơm ngon, ngọt thịt dê ăn kèm với bún, mì và các loại rau', 499000, 3, N'https://cdn.tgdd.vn/Files/2021/12/08/1403295/tong-hop-cac-mon-lau-ngon-de-lam-ma-ban-khong-nen-bo-qua-202112082047138424.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (32, N'Lẩu vịt', N'Thịt vịt thì mềm mềm, dai dai, béo béo ăn kèm rau và bún thì không còn gì để bàn cãi.', 499000, 3, N'https://cdn.tgdd.vn/Files/2020/01/08/1230632/2-cach-lam-lau-vit-om-sau-lau-vit-nuoc-dua-don-gian-ma-thom-ngon-19.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (33, N'Chè đậu các loại', N'Đậu đen, đậu xanh, đậu đỏ hoặc đậu trắng,... Món chè đậu thơm ngon ăn kèm nước cốt dừa, có thể ăn nóng hoặc lạnh', 60000, 4, N'https://cdn.tgdd.vn/Files/2021/08/20/1376549/top-15-mon-trang-mieng-viet-nam-ngon-nhat-ma-ban-nen-biet-202108201444523994.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (34, N'Chè vải hạt sen', N'Có tác dụng thanh nhiệt cơ thể. Hạt sen giòn giòn, bùi bùi, vải ngọt thanh, thơm ngon.', 60000, 4, N'https://cdn.tgdd.vn/Files/2021/08/20/1376549/top-15-mon-trang-mieng-viet-nam-ngon-nhat-ma-ban-nen-biet-202108201445168873.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (35, N'Bánh chuối nướng', N'Món bánh tơi xốp có vị ngọt vừa phải của chuối, mùi thơm nồng nàn, rất kích thích vị giác.', 60000, 4, N'https://cdn.tgdd.vn/Files/2021/08/20/1376549/top-15-mon-trang-mieng-viet-nam-ngon-nhat-ma-ban-nen-biet-202108201445333508.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (37, N'Bánh da lợn', N'Bánh thơm mát mùi lá dứa, ngọt bùi hương vị đậu xanh. Bánh mềm, mịn và dẻo vừa ăn.', 60000, 4, N'https://cdn.tgdd.vn/Files/2021/08/20/1376549/top-15-mon-trang-mieng-viet-nam-ngon-nhat-ma-ban-nen-biet-202108201445506320.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (38, N'Sương sáo nước cốt dừa', N'Sương sáo dai dai, mềm mềm ăn kèm với nước cốt dừa béo béo, thêm vài viên đá mát lạnh', 60000, 4, N'https://cdn.tgdd.vn/Files/2021/08/20/1376549/top-15-mon-trang-mieng-viet-nam-ngon-nhat-ma-ban-nen-biet-202108201446036682.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (39, N'Chè dừa dầm', N'Chè có vị ngọt thanh, béo béo của sữa dừa, phần cùi dừa dai mềm vừa phải', 60000, 4, N'https://cdn.tgdd.vn/Files/2021/08/20/1376549/top-15-mon-trang-mieng-viet-nam-ngon-nhat-ma-ban-nen-biet-202108201446192185.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (40, N'Bánh chuối hấp nước cốt dừa', N'Bánh chuối mềm, dẻo và ngọt vừa ăn, ăn kèm nước cốt dừa thơm, béo.', 60000, 4, N'https://cdn.tgdd.vn/Files/2021/08/20/1376549/top-15-mon-trang-mieng-viet-nam-ngon-nhat-ma-ban-nen-biet-202108201446325834.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (41, N'Chè 3 màu', N'Chè 3 màu là sự kết hợp hài hòa của ba loại đậu (đỏ, trắng, xanh), thạch lá dứa và nước cốt dừa', 60000, 4, N'https://cdn.tgdd.vn/Files/2021/08/20/1376549/top-15-mon-trang-mieng-viet-nam-ngon-nhat-ma-ban-nen-biet-202108201446466089.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (44, N'Gỏi sứa', N'Gia vị chua ngọt thấm đều vào từng con sứa trong suốt, giòn sần sật hấp dẫn nhiều thực khách. Sứa phải được xử lý rất cẩn thận', 45000, 1, N'https://cdn.tgdd.vn/Files/2017/10/11/1032138/3-cach-lam-goi-sua-hoa-chuoi-ngon-gion-san-sat-don-gian-202106262213318937.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (45, N'Mực nướng sa tế', N'Mực chín vàng đều 2 mặt không bị cháy, thịt mực giòn, ngọt, đậm đà kết hợp cùng chút cay cay của sa tế.', 60000, 2, N'https://cdn.tgdd.vn/2020/07/CookRecipe/Avatar/muc-nuong-sa-te-ngon-voi-sot-uop-chuan-thumbnail-1.jpg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (47, N'Lẩu ếch', N'Lẩu ếch có mùi thơm đặc trưng của hành, ngò, chanh, sả, thịt ếch thì mềm dai, không bị bỡ, ngọt tự nhiên, đậm đà thấm vị vô cùng thơm ngon.', 499000, 3, N'https://bepmina.vn/wp-content/uploads/2021/09/lam-lau-ech-mang-cay.jpeg')
GO
INSERT [dbo].[Food] ([Food_id], [Food_name], [Food_description], [Food_price], [Food_category], [Food_image]) VALUES (49, N'Chè nhãn nhục', N'Chè nhãn nhục thường được nấu với đường phèn nên ngọt thanh. Nhãn nhục ngọt, mọng nước, bạn có thể thêm vào hạt sen, táo tàu, củ năng', 60000, 4, N'https://cdn.tgdd.vn/Files/2021/08/20/1376549/top-15-mon-trang-mieng-viet-nam-ngon-nhat-ma-ban-nen-biet-202108201447056338.jpg')
GO
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([User_id], [Username], [Email], [Password], [Phone], [Role]) VALUES (1, N'admin', N'admin@gmail.com', N'123', N'12345671', 2)
GO
INSERT [dbo].[User] ([User_id], [Username], [Email], [Password], [Phone], [Role]) VALUES (2, N'tan', N'tannmhe160735@fpt.edu.vn', N'1234567', N'12315134', 1)
GO
INSERT [dbo].[User] ([User_id], [Username], [Email], [Password], [Phone], [Role]) VALUES (1006, N'tannnnnnn', N'tan123@gmail.com', N'123', N'0', 0)
GO
INSERT [dbo].[User] ([User_id], [Username], [Email], [Password], [Phone], [Role]) VALUES (1007, N'tan123', N'tan1233@gmail.com', N'123', N'0', 1)
GO
INSERT [dbo].[User] ([User_id], [Username], [Email], [Password], [Phone], [Role]) VALUES (2007, N'tan1234', N'tan1234@gmail.com', N'123', N'0', 1)
GO
INSERT [dbo].[User] ([User_id], [Username], [Email], [Password], [Phone], [Role]) VALUES (2008, N'tan12345', N'thanh@gmail.com', N'123', N'0', 1)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_Food_Category] FOREIGN KEY([Food_category])
REFERENCES [dbo].[Category] ([Category_id])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_Food_Category]
GO
