--liquibase formatted sql

--changeset balances:1
CREATE TABLE IF NOT EXISTS balances
(
    id        BIGSERIAL,
    from_user VARCHAR(255)
);
