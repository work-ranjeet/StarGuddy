
export enum Expertlavel {
    Beginner = 1,
    Intermediate = 10,
    Expert = 20
};

export enum AgentNeed {
    "I don't have an agent" = 100,
    "I want an agent" = 101,
    "I have an agent" = 102
};

export enum ActingExperiance {
    "No previous acting experience" = 200,
    "Credits" = 201,
    "Previous unpaid speaking roles" = 202,
    "Previous paid speaking roles" = 203
};

export enum ModelingExperiance {
    "Beginner, starting out" = 300,
    "Part-time model - paid commercial work" = 301,
    "Full-time model - paid commercial work" = 302
};


// Exporting all enums
export * from "../Enums/enums";