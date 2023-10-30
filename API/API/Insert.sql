GO

/*******************************************************************************
   Create Tables
********************************************************************************/

CREATE TABLE Habits (
    ID INT IDENTITY PRIMARY KEY,
    Name VARCHAR(255),
    Frequency INT,
    Repeat INT,
    StartDate DATE
);

CREATE TABLE Progresses (
    ID INT IDENTITY, 
    HabitID INT,
    HabitProgress INT,
    IsCompleted BIT,
    Note TEXT,
    EndDate DATE,
    PRIMARY KEY (HabitID, ID),
    FOREIGN KEY (HabitID) REFERENCES Habits (ID)
);

/*******************************************************************************
   Populate Tables
********************************************************************************/

INSERT INTO [Habits] ([Name], [Frequency], [Repeat], [StartDate])
VALUES 
('Exercise', 5, 1, '2023-10-25'),
('Reading', 3, 2, '2023-10-26'),
('Running', 4, 1, '2023-10-25'),
('Meditation', 7, 2, '2023-10-25'),
('Eat healthy foods', 7, 1, '2023-10-25'),
('Write in a journal', 1, 0, '2023-10-25'),
('Drink water', 8, 2, '2023-10-25'),
('Wake up early', 1, 1, '2023-10-30'),
('Learn a new language', 30, 2, '2023-08-30'),
('Play a musical instrument', 60, 0, '2023-09-30'),
('Volunteer', 2, 1, '2023-10-30'),
('Cook a healthy meal', 3, 0, '2023-09-30'),
('Spend time with loved ones', 1, 2, '2023-10-30'),
('Spend 1 hour outside', 1, 1, '2023-10-31'),
('Save $10', 1, 0, '2023-10-31');



INSERT INTO [Progresses] ([HabitID], [HabitProgress], [IsCompleted], [Note], [EndDate])
VALUES 
(1,  100, 1, 'Feeling great!', '2023-10-29'),
(2, 50, 1, 'Finished a book!', '2023-10-27'),
(3, 80, 1, 'Improved my pace', '2023-10-28'),
(4, 70, 1, 'Feeling calm and focused', '2023-10-30'),
(5, 90, 1, 'Ate mostly healthy foods.', '2023-10-29'),
(6, 60, 1, 'Wrote in my journal for 10 minutes.', '2023-10-29'),
(7, 50, 1, 'Staying hydrated.', '2023-10-29'),
(8, 100, 1, 'Feeling refreshed and ready for the day!', '2023-10-30'),
(9, 70, 1, 'Expanding my vocabulary.', '2023-10-30'),
(10, 60, 1, 'Improving my skills.', '2023-10-30'),
(11, 50, 1, 'Making a difference in my community.', '2023-12-30'),
(12, 60, 1, 'Eating healthier and feeling better.', '2023-12-30'),
(13, 50, 1, 'Connecting with the people I care about.', '2023-10-30'),
(14, 30, 1, 'Getting some fresh air and sunshine.', '2023-12-01'),
(15, 20, 1, 'Reaching my financial goals.', '2023-11-03');



/*******************************************************************************
   Drop Tables
********************************************************************************/

DROP TABLE Progresses, Habits
	