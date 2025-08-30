
create database movie
go
use movie
go
create schema cinema
go
create table cinema.actor(
     act_id int primary key,
	 act_fname varchar(20),
	 act__lname varchar(20),
	 act_gendar char(1)
)
create table cinema.director(
     dirc_id int primary key,
	 dirc_fname varchar(20),
	 dirc_lname varchar(20)
)
create table cinema.movies(
     movie_id int primary key,
	 movie_title varchar(30),
	 movie_year int,
	 movie_time int,
	 movie_lang varchar(20),
	 movie_dt_rl datetime2,
	 movie_rel_country varchar(30)
)
create table cinema.reviewr(
     rev_id int primary key,
	 rev_name varchar(30)
)
create table cinema.genres(
     gen_id int primary key,
	 gen_title varchar(50)
)
create table cinema.movie_dirction(
     dir_id int primary key,
	 movie_id int references cinema.movies(movie_id)
)
create table cinema.movie_cast(
     act_id int references cinema.actor(act_id),
	 movie_id int references cinema.movies(movie_id),
	 role varchar(30)
)
create table cinema.movie_gen(
     movie_id int references cinema.movies(movie_id),
	 gen_id int references cinema.genres(gen_id)
)
create table cinema.rating(
     rev_stars int,
	 num_o_rating int,
	 movie_id int references cinema.movies(movie_id),
	 rev_id int references cinema.reviewr(rev_id)
)
