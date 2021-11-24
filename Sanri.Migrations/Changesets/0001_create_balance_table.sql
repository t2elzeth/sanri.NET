--liquibase formatted sql

--changeset balances:10
create table public.balances
(
    id        BIGSERIAL,
    from_user VARCHAR(255),
    balance   decimal not null
);
--rollback drop table public.balances;