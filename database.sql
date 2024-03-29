USE [Hotel]
GO
SET IDENTITY_INSERT [dbo].[Amenities] ON 

INSERT [dbo].[Amenities] ([Id], [Name], [Icon]) VALUES (1, N'WiFi', N'wifi')
INSERT [dbo].[Amenities] ([Id], [Name], [Icon]) VALUES (2, N'TV', N'tv')
INSERT [dbo].[Amenities] ([Id], [Name], [Icon]) VALUES (3, N'Safe', N'local_hospital')
INSERT [dbo].[Amenities] ([Id], [Name], [Icon]) VALUES (4, N'Minibar', N'local_bar')
INSERT [dbo].[Amenities] ([Id], [Name], [Icon]) VALUES (5, N'Telephone', N'local_phone')
INSERT [dbo].[Amenities] ([Id], [Name], [Icon]) VALUES (6, N'Kitchen', N'local_dining')
INSERT [dbo].[Amenities] ([Id], [Name], [Icon]) VALUES (7, N'Parking', N'local_parking')
INSERT [dbo].[Amenities] ([Id], [Name], [Icon]) VALUES (8, N'Work Space', N'group_work')
INSERT [dbo].[Amenities] ([Id], [Name], [Icon]) VALUES (9, N'New Reapired', N'build')
SET IDENTITY_INSERT [dbo].[Amenities] OFF
SET IDENTITY_INSERT [dbo].[Apartments] ON 

INSERT [dbo].[Apartments] ([Id], [Title], [Subtitle], [Price], [Info], [Limit], [BedCount], [Size]) VALUES (33, N'Junior Suite', N'Our Junior Suites offer breathtaking views of the city skyline.

', 250, N'Affordable luxury. Our Junior Suites are the perfect option if you’re looking for a little extra luxury. With an open 400 square foot floor plan, the Junior Suites offer the extra space you need to spread out and enjoy the breathtaking views of the city skyline.

', 2, N'2 Double(s)', N'260 sq ft')
INSERT [dbo].[Apartments] ([Id], [Title], [Subtitle], [Price], [Info], [Limit], [BedCount], [Size]) VALUES (34, N'Standard Room', N'Our Standard Rooms are the perfect combination of function and comfort.

', 150, N'Functional and comfortable. Sit back and enjoy one of our brand new 280 square foot Standard Rooms. Complete with courtyard views, stylish decor and natural light, our Standard Rooms are the perfect combination of function and comfort. Ideally suited for today’s business or leisure travelers.

', 2, N'1 Double(s)', N'230 sq ft')
INSERT [dbo].[Apartments] ([Id], [Title], [Subtitle], [Price], [Info], [Limit], [BedCount], [Size]) VALUES (35, N'Superior Room', N'Our Superior Rooms are comfortable, roomy and elegant.

', 350, N'Elegant simplicity. Our Superior Rooms give you the space and privacy you need to work or play on the road. The spacious 380 square foot rooms include an intimate lounge area, business workstation and views of the courtyard. Complete with all the regular amenities, our Superior Rooms also include a daily newspaper and water bottles.

', 2, N'1 King(s)', N'280 sq ft')
SET IDENTITY_INSERT [dbo].[Apartments] OFF
SET IDENTITY_INSERT [dbo].[ApartmentToAmenities] ON 

INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (27, 33, 1)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (28, 33, 2)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (30, 33, 3)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (31, 33, 4)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (32, 33, 5)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (34, 33, 6)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (35, 34, 1)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (36, 34, 2)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (37, 34, 7)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (38, 34, 5)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (40, 35, 1)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (41, 35, 3)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (42, 35, 7)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (43, 35, 8)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (44, 35, 9)
INSERT [dbo].[ApartmentToAmenities] ([Id], [ApartmentId], [AmenityId]) VALUES (50, 35, 6)
SET IDENTITY_INSERT [dbo].[ApartmentToAmenities] OFF
SET IDENTITY_INSERT [dbo].[ApartmentImages] ON 

INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (27, N'apartment-1.1.jpg', 33)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (28, N'apartment-1.2.jpg', 33)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (30, N'apartment-1.3.jpg', 33)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (31, N'apartment-1.4.jpg', 33)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (33, N'apartment-1.5.jpg', 33)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (34, N'apartment-1.1.jpg', 34)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (35, N'apartment-1.2.jpg', 34)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (36, N'apartment-1.3.jpg', 34)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (37, N'apartment-1.4.jpg', 34)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (38, N'apartment-1.5.jpg', 34)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (39, N'apartment-1.1.jpg', 35)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (41, N'apartment-1.2.jpg', 35)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (43, N'apartment-1.3.jpg', 35)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (44, N'apartment-1.4.jpg', 35)
INSERT [dbo].[ApartmentImages] ([Id], [Name], [ApartmentId]) VALUES (45, N'apartment-1.5.jpg', 35)
SET IDENTITY_INSERT [dbo].[ApartmentImages] OFF
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([Id], [AdultsCount], [KidsCount], [StartDate], [EndDate], [Name], [Surname], [Phone], [Email], [Country], [SpecialRequest], [ApartmentId], [Amount], [CreatedDate], [IsActive], [Tax], [TotalAmount]) VALUES (6, 1, 1, CAST(N'2022-03-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-27T00:00:00.0000000' AS DateTime2), N'Shahin', N'Babayev', N'0515319232', N'shahinhb@code.edu.az', N'Afganistan', N'23131', 35, 900, CAST(N'2022-03-04T19:13:58.5355888' AS DateTime2), 0, 0, 0)
INSERT [dbo].[Reservations] ([Id], [AdultsCount], [KidsCount], [StartDate], [EndDate], [Name], [Surname], [Phone], [Email], [Country], [SpecialRequest], [ApartmentId], [Amount], [CreatedDate], [IsActive], [Tax], [TotalAmount]) VALUES (7, 1, 1, CAST(N'2022-03-18T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-21T00:00:00.0000000' AS DateTime2), N'Shahin', N'Babayev', N'0515319232', N'shahinhb@code.edu.az', N'Bahrain', N'1122121', 33, 0, CAST(N'2022-03-05T21:17:21.3672860' AS DateTime2), 1, 0, 0)
INSERT [dbo].[Reservations] ([Id], [AdultsCount], [KidsCount], [StartDate], [EndDate], [Name], [Surname], [Phone], [Email], [Country], [SpecialRequest], [ApartmentId], [Amount], [CreatedDate], [IsActive], [Tax], [TotalAmount]) VALUES (8, 1, 1, CAST(N'2022-03-07T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-17T00:00:00.0000000' AS DateTime2), N'Shahin', N'Babayev', N'0515319232', N'shahinhb@code.edu.az', N'Austria', N'1sddasdasd', 33, 2500, CAST(N'2022-03-07T00:44:15.2581905' AS DateTime2), 1, 525, 3025)
INSERT [dbo].[Reservations] ([Id], [AdultsCount], [KidsCount], [StartDate], [EndDate], [Name], [Surname], [Phone], [Email], [Country], [SpecialRequest], [ApartmentId], [Amount], [CreatedDate], [IsActive], [Tax], [TotalAmount]) VALUES (10, 1, 1, CAST(N'2022-03-15T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-17T00:00:00.0000000' AS DateTime2), N'Shahin', N'Babayev', N'0515319232', N'shahinhb@code.edu.az', N'Bahamas', N'Please send me tea', 35, 700, CAST(N'2022-03-11T13:47:38.0968891' AS DateTime2), 0, 147, 847)
INSERT [dbo].[Reservations] ([Id], [AdultsCount], [KidsCount], [StartDate], [EndDate], [Name], [Surname], [Phone], [Email], [Country], [SpecialRequest], [ApartmentId], [Amount], [CreatedDate], [IsActive], [Tax], [TotalAmount]) VALUES (11, 1, 1, CAST(N'2022-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-31T00:00:00.0000000' AS DateTime2), N'Charlie', N'Adams', N'0515319232', N'shahinhb@code.edu.az', N'Great Britain', NULL, 34, 1650, CAST(N'2022-03-11T20:07:41.3247646' AS DateTime2), 0, 346.5, 1996.5)
INSERT [dbo].[Reservations] ([Id], [AdultsCount], [KidsCount], [StartDate], [EndDate], [Name], [Surname], [Phone], [Email], [Country], [SpecialRequest], [ApartmentId], [Amount], [CreatedDate], [IsActive], [Tax], [TotalAmount]) VALUES (12, 1, 1, CAST(N'2022-04-13T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-23T00:00:00.0000000' AS DateTime2), N'Tom', N'Allen', N'12312312', N'shahinhb@code.edu.az', N'United States of America', NULL, 33, 2500, CAST(N'2022-03-11T20:13:02.5010463' AS DateTime2), 0, 525, 3025)
INSERT [dbo].[Reservations] ([Id], [AdultsCount], [KidsCount], [StartDate], [EndDate], [Name], [Surname], [Phone], [Email], [Country], [SpecialRequest], [ApartmentId], [Amount], [CreatedDate], [IsActive], [Tax], [TotalAmount]) VALUES (13, 1, 1, CAST(N'2022-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-05T00:00:00.0000000' AS DateTime2), N'Alphonso', N'Rodriguez', N'0515319232', N'shahinhb@code.edu.az', N'Mexico', NULL, 34, 600, CAST(N'2022-03-11T20:20:14.1030713' AS DateTime2), 0, 126, 726)
INSERT [dbo].[Reservations] ([Id], [AdultsCount], [KidsCount], [StartDate], [EndDate], [Name], [Surname], [Phone], [Email], [Country], [SpecialRequest], [ApartmentId], [Amount], [CreatedDate], [IsActive], [Tax], [TotalAmount]) VALUES (14, 1, 1, CAST(N'2022-03-11T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-12T00:00:00.0000000' AS DateTime2), N'Alphonso', N'Davies', N'0515319232', N'shahinhb@code.edu.az', N'Canada', NULL, 35, 350, CAST(N'2022-03-11T20:25:25.0667841' AS DateTime2), 0, 73.5, 423.5)
INSERT [dbo].[Reservations] ([Id], [AdultsCount], [KidsCount], [StartDate], [EndDate], [Name], [Surname], [Phone], [Email], [Country], [SpecialRequest], [ApartmentId], [Amount], [CreatedDate], [IsActive], [Tax], [TotalAmount]) VALUES (17, 1, 1, CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-01-17T00:00:00.0000000' AS DateTime2), N'Sammir', N'Marco', N'0515319232', N'shahinhb@code.edu.az', N'Croatia', NULL, 35, 5600, CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), 1, 1176, 6776)
INSERT [dbo].[Reservations] ([Id], [AdultsCount], [KidsCount], [StartDate], [EndDate], [Name], [Surname], [Phone], [Email], [Country], [SpecialRequest], [ApartmentId], [Amount], [CreatedDate], [IsActive], [Tax], [TotalAmount]) VALUES (18, 1, 1, CAST(N'2022-02-16T00:00:00.0000000' AS DateTime2), CAST(N'2022-02-27T00:00:00.0000000' AS DateTime2), N'Marco', N'Mora', N'0515319232', N'shahinhb@code.edu.az', N'Chile', NULL, 35, 3850, CAST(N'2022-02-10T00:00:00.0000000' AS DateTime2), 1, 8085, 46585)
SET IDENTITY_INSERT [dbo].[Reservations] OFF
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'03a6b8a4-d09b-4839-a1d2-1440698ecb47', N'SUPERADMIN', N'SUPERADMIN', N'15a49a09-c06a-4a84-9ed8-f49ef2d2c71e')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'130d7f29-df7c-4f8a-851f-e30cc0495886', N'ADMIN', N'ADMIN', N'05ba0d94-dbe7-4490-a73f-7ba2fcd4afdb')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1fb90593-be45-4973-b2db-2c5cb61f450f', N'MODERATOR', N'MODERATOR', N'6928ee6b-ca6d-414d-98d9-10b5f0e36ccf')
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Image], [Name], [Surname], [CreatedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Position], [Address]) VALUES (N'1c83328d-0fcd-424f-bfdb-cf1093c8248f', N'AdminPanelUser', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Michael', N'MICHAEL', NULL, NULL, 0, N'AQAAAAEAACcQAAAAELCC8tzYK5USuUmLfgt1wTaIciCHeBfrafuLEp44g0e8K36DdBMID3ZMJf8s0Na2VQ==', N'RB42KTUXKVWFRJXMEA5VINKBJVR6IDCY', N'3eb19fba-b07a-4272-adb1-9597d725267d', NULL, 0, 0, NULL, 1, 0, N'Engineer', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Image], [Name], [Surname], [CreatedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Position], [Address]) VALUES (N'351d71d6-1519-4fb1-9921-ca1aa30bf79a', N'AdminPanelUser', N'Shahin.jpg', N'Shahin', N'Babayev', CAST(N'2021-01-31T00:00:00.0000000' AS DateTime2), N'Shahin', N'SHAHIN', N'shahinbabayev98@gmail.com', N'SHAHINBABAYEV98@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKHdw0dqsPNmxictapxoc+shbDzd5c9g/CA+tFsG/CyxLdxxzEy74FvV+jakkrihFA==', N'I5Z5KJ6VM3KEML2O5YA3I7BBFGNSCCVN', N'3c6a1465-43b5-4cdb-8e1b-b542cf1dd734', N'+994515319232', 0, 0, NULL, 1, 0, N'CEO', N'Nizami region, I.Mammadov str')
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Image], [Name], [Surname], [CreatedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Position], [Address]) VALUES (N'65d31b50-4722-475c-8eaa-6f12e0265ab8', N'AdminPanelUser', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Tobey', N'TOBEY', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEESgDn8J0clsi0KY02ko5i/uDxk/OtJvzjagn3Zu1JYO1RAbMD93ZXZZeHjB2UIZFw==', N'5LVVZV5DYYJOYUV5QWVQEHA5OOX3I7MT', N'f5606c9f-93a3-4386-96a2-160a9977b833', NULL, 0, 0, NULL, 1, 0, N'Actor', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Image], [Name], [Surname], [CreatedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Position], [Address]) VALUES (N'aaceca0c-80d8-4a5e-882b-432192f88cb3', N'AdminPanelUser', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Tom', N'TOM', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEPKPH41D5ibUtR6M6TMB+Ar8LHUYhhsTHTbIn2yo+TKP2913Fe1su0/ubNrbr1WwGA==', N'XDO363TVH4MMWL2PZ7TXIUTKKNODMJKG', N'81c54c34-1f71-4aca-8ff3-863682dfd359', NULL, 0, 0, NULL, 1, 0, N'HR', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Image], [Name], [Surname], [CreatedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Position], [Address]) VALUES (N'ad7afd97-c2c0-4e19-b7c9-6f2cb253d455', N'AdminPanelUser', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'David', N'DAVID', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEGoOIQY6ewNFXud7i6q2bFS6bg/9tSi080bXdK0cDcWrCzqpvfWbuBnELvI0aiR70A==', N'K7UUEQ5QCMNJ5DBJ23IRQSOTVYLZ5RFH', N'f4a7baa0-8d9c-4703-a2df-719e5858740d', NULL, 0, 0, NULL, 1, 0, N'Project Manager', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Image], [Name], [Surname], [CreatedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Position], [Address]) VALUES (N'd306555a-b64f-4373-a1bf-7d66eca688ff', N'AdminPanelUser', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Miguel', N'MIGUEL', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEP/P3zWs9kYv/4GP/BxE4zRLIfJWz5lX+AIbSgid0S26vNfKIm9/M5vnpBI8+uBqlQ==', N'R44APNMLWPWGT4VJNCGJBUW5N7QXWJKI', N'f222bc30-3309-469a-a903-cd770f94e866', NULL, 0, 0, NULL, 1, 0, N'Developer', NULL)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'351d71d6-1519-4fb1-9921-ca1aa30bf79a', N'03a6b8a4-d09b-4839-a1d2-1440698ecb47')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'65d31b50-4722-475c-8eaa-6f12e0265ab8', N'130d7f29-df7c-4f8a-851f-e30cc0495886')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ad7afd97-c2c0-4e19-b7c9-6f2cb253d455', N'130d7f29-df7c-4f8a-851f-e30cc0495886')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1c83328d-0fcd-424f-bfdb-cf1093c8248f', N'1fb90593-be45-4973-b2db-2c5cb61f450f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aaceca0c-80d8-4a5e-882b-432192f88cb3', N'1fb90593-be45-4973-b2db-2c5cb61f450f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd306555a-b64f-4373-a1bf-7d66eca688ff', N'1fb90593-be45-4973-b2db-2c5cb61f450f')
SET IDENTITY_INSERT [dbo].[Aboutapartments] ON 

INSERT [dbo].[Aboutapartments] ([Id], [Title], [Content]) VALUES (1, N'Our Apartment', N'<p>The apartment is spacious with high ceilings, large windows, an open balcony and a beautiful view of the beach. Stay cool with central A/C and wind-down comfortably in the queen sized bedroom.</p>')
SET IDENTITY_INSERT [dbo].[Aboutapartments] OFF
SET IDENTITY_INSERT [dbo].[AboutCities] ON 

INSERT [dbo].[AboutCities] ([Id], [Title], [Content]) VALUES (1, N'The Marvelous City', N'<p>Create memories of a lifetime in one of the most beautiful cities in the world -&nbsp;<strong>Rio de Janeiro</strong>.&nbsp;Relax on gorgeous white sandy beaches, explore a cultural hub of art and entertainment, or check out the many famous landmarks around the city.</p>')
SET IDENTITY_INSERT [dbo].[AboutCities] OFF
SET IDENTITY_INSERT [dbo].[AboutGames] ON 

INSERT [dbo].[AboutGames] ([Id], [Title], [Content]) VALUES (1, N'The Games', N'<p>Be where the action is. Witness 10,500 athletes from around the world compete in 306 medal events. Celebrate the wins and cheer your nation on. When it comes to The Games, you&rsquo;ll want to be there.&nbsp;Check the official Games website for updates on events and locations</p>')
SET IDENTITY_INSERT [dbo].[AboutGames] OFF
SET IDENTITY_INSERT [dbo].[Feedbacks] ON 

INSERT [dbo].[Feedbacks] ([Id], [Title], [Content]) VALUES (1, N'About Camila & Tiago 
', N'Hi, my name is Camila and I’m a nutritionist from the south of Brazil. I moved to the beautiful Ipanema neighborhood two years ago with my husband, Tiago. We live in a homie highrise just off the Leblon Beach, but in the summer we travel!

')
SET IDENTITY_INSERT [dbo].[Feedbacks] OFF
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([Id], [Title], [Content]) VALUES (1, N'Location
', N'Conveniently located just opposite Leblon Beach in Ipanema, our apartment will sweep you into the charm and excitements of Rio! Dine at one of our neighborhood’s many world-renowned restaurants, enjoy fresh-squeezed juices from one of the colourful stalls along the beach, and don’t miss live bossy-nova show in one of the local bars.

')
SET IDENTITY_INSERT [dbo].[Locations] OFF
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([Id], [Name], [Email], [Content], [IsReplied]) VALUES (19, N'e', N'sahin_babayev_98@mail.ru', N'qweqw', 1)
SET IDENTITY_INSERT [dbo].[Messages] OFF
SET IDENTITY_INSERT [dbo].[Pages] ON 

INSERT [dbo].[Pages] ([Id], [Name], [Title], [Subtitle], [ImageName]) VALUES (8, N'Home', N'Welcome to Rio', N'BE MY GUEST', N'bg-home.png')
INSERT [dbo].[Pages] ([Id], [Name], [Title], [Subtitle], [ImageName]) VALUES (9, N'Apartment', N'Our Apartment', NULL, N'bg-apartment.png')
INSERT [dbo].[Pages] ([Id], [Name], [Title], [Subtitle], [ImageName]) VALUES (10, N'About', N'Rio De Janeiro
', NULL, N'bg-about.png')
INSERT [dbo].[Pages] ([Id], [Name], [Title], [Subtitle], [ImageName]) VALUES (11, N'Contact', N'Contact Us', NULL, N'bg-contact.png')
SET IDENTITY_INSERT [dbo].[Pages] OFF
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [Email], [Phone], [Address]) VALUES (1, N'apartmentsbookingrio@gmail.com', N'123-456-7890', N'<p>R. Frame de Mor&aacute;</p><p>Floor 6</p><p>Rio de Janeiro - Ipanema</p>')
SET IDENTITY_INSERT [dbo].[Settings] OFF
SET IDENTITY_INSERT [dbo].[Socials] ON 

INSERT [dbo].[Socials] ([Id], [Name], [Icon], [Link]) VALUES (1, N'Instagram', N'icon-social-instagram', N'instagram.com')
INSERT [dbo].[Socials] ([Id], [Name], [Icon], [Link]) VALUES (2, N'Facebook', N'icon-social-facebook', N'facebook.com')
INSERT [dbo].[Socials] ([Id], [Name], [Icon], [Link]) VALUES (3, N'Twitter', N'icon-social-twitter', N'https://twitter.com/')
SET IDENTITY_INSERT [dbo].[Socials] OFF
SET IDENTITY_INSERT [dbo].[Subs] ON 

INSERT [dbo].[Subs] ([Id], [MailAddress], [CreatedDate]) VALUES (12, N'akhmad.arabi@mail.ru', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subs] ([Id], [MailAddress], [CreatedDate]) VALUES (23, N'falxasov@list.ru', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subs] ([Id], [MailAddress], [CreatedDate]) VALUES (26, N'satiram96@mail.ru', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subs] ([Id], [MailAddress], [CreatedDate]) VALUES (27, N'sahin_babayev_98@mail.ru', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subs] ([Id], [MailAddress], [CreatedDate]) VALUES (29, N'shahinhb@code.edu.az', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subs] ([Id], [MailAddress], [CreatedDate]) VALUES (30, N'shahinbabayev98@gmail.com', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subs] ([Id], [MailAddress], [CreatedDate]) VALUES (31, N'asddasad@gmail.com', CAST(N'2022-03-11T13:51:05.7791644' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Subs] OFF
