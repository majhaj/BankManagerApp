CREATE TABLE AccountTransactionApprovement(
    TransactionId int not null,
    ApprovementId int not null,
    PRIMARY KEY ( TransactionId, ApprovementId )
);