create database usermanagement;
set search_path to usermanagement;

create extension "uuid-ossp";

create table pessoa (
	id uuid not null default uuid_generate_v4(),
	nome varchar(100) not null,
	cep varchar(8) not null,
	logradouro varchar(255) null,
	constraint pessoa_pk primary key (id) 
);

create table "user" (
	email varchar(150) not null,
	senha varchar(64) not null,
	unique(email)
) inherits (pessoa);