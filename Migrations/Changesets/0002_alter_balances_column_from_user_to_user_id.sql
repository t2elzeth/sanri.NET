--liquibase formatted sql

--changeset balances:2
alter table public.balances
    rename column from_user to user_id;
alter table public.balances
    alter column user_id type int USING balances.user_id::integer;
alter table public.balances
    add constraint fk_balance_user FOREIGN KEY (user_id) REFERENCES users (id);
--rollback ;