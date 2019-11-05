

begin tran 
delete from books; 
insert into books (Title, Author, GutenbergId, Body)
values 
('Dracula', 'Bram Stoker', 1, 'Jaws but with a Vampire'),
('Brothers Karamazov', 'Fyodor Dostoevsky', 2, 'If God does not exist, all is permissable'),
('Moby Dick', 'Herman Melville', 3, 'Thar she blows!'),
('Pride and Prejudice', 'Jane Austen', 4, 'Conversation, some sad boys')
select * from books;
commit
--rollback