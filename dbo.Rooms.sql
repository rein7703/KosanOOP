CREATE TABLE [dbo].[Rooms] (
    [roomName]  VARCHAR (50) NOT NULL,
    [roomPrice] BIGINT       NULL,
    [isFilled]  VARCHAR (50) NULL,
    [isPaid]    VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([roomName] ASC)
);

