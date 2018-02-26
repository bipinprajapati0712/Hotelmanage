use DB09TMS101_1718
create table meri_booking
(bid int identity(1000,1),
name varchar(80),
age int,
contact bigint,
email varchar(80),
adds varchar(80),
roomcat varchar(10),
nodays int,
rent int
)
select * from meri_booking
create proc booking_ka_proc

@bid int out,@name varchar(80),@age int,@con bigint,@em varchar(80),@adds varchar(80),@cat varchar(10),@day int,@rent int
as
begin
insert into meri_booking values(@name,@age ,@con ,@em,@adds,@cat,@day ,@rent )
set @bid = @@IDENTITY
end;
create proc room_ki_cat 
@roomcat varchar(10)
as begin
select* from meri_booking where  roomcat=@roomcat
end;
