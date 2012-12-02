using System;

namespace Recognition.Application
{
    [Flags]
    public enum PanelsState
    {
        AllEnabled = 0x0,
        OpeningDisabled = 0x1,
        StartTrainingDisabled = 0x2,
        StopTrainingDisabled = 0x4,
        TrainingDisabled = StartTrainingDisabled | StopTrainingDisabled,
        StartTestingDisabled = 0x8,
        StopTestingDisabled = 0x10,
        TestingDisabled = StartTestingDisabled | StopTestingDisabled,
        RecognizingDisabled = 0x20,

        TrainingNow = OpeningDisabled | StartTrainingDisabled | TestingDisabled | RecognizingDisabled,
        TestingNow = OpeningDisabled | TrainingDisabled | StartTestingDisabled | RecognizingDisabled
    }
}