Create database Lib;
use Lib;

drop table Author;
create table Author(
	id_author int constraint PK_author primary key check(id_author>0),
	psevdo nvarchar(30) check(psevdo not like '%[^a-zA-Zà-ÿÀ-ß- ]%') not null ,
	country nvarchar(20) check(country not like '%[^a-zA-Zà-ÿÀ-ß- ]%'),
	byear int check(byear > 1400 and byear < 2008)
);

select * from author;

insert author values(1, 'asdf', 'sdfj', 2000);

drop table Book;
create table Book(
	id_book int identity(1, 1) constraint PK_book primary key,
	bname nvarchar(20) not null,
	author int not null constraint FK_author foreign key references Author(id_author) ON DELETE CASCADE,
	image nvarchar(max),
	publish_year int check(publish_year > 1457 and publish_year < 2024),
	publisher nvarchar(20) not null ,
	num_pages int check(num_pages > 0),
	num_chapt int check(num_chapt > 0),
	format nvarchar(5) check(format in ('fb2', 'epub', 'text', 'pdf')),
	size real check(size > 0)
);

insert book values('sdfg', 1, '/Resources/cover1.jpg', 2023, 'dfeg2', '5', '8', 'pdf', 23.45);

select * from book;

select @@Servername

select bname, psevdo, num_chapt, num_chapt, size, format from book join author on author = id_author where format=@x;

drop procedure addAuthor
create procedure addAuthor
	@id_author int,
	@psevdo nvarchar(30),
	@country nvarchar(20),
	@byear int
as
begin
	insert author values(@id_author, @psevdo, @country, @byear);
end
go

drop procedure addBook
create procedure addBook
	@bname nvarchar(20),
	@author int,
	@publish_year int,
	@publisher nvarchar(20),
	@num_pages int,
	@num_chapt int,
	@format nvarchar(5),
	@size real,
	@image nvarchar(max)
as
begin
	insert book values(@bname, @author, @publish_year, @publisher, @num_pages, @num_chapt, @format, @size, @image);
end
go