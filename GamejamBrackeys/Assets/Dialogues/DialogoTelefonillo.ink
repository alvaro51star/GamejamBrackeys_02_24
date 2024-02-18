EXTERNAL getNumberOfTries()
EXTERNAL getNumberOfBadGuysInside()
VAR numberOfTries = 0
~numberOfTries = getNumberOfTries()
VAR numberOfBadGuysInside = 0
~numberOfBadGuysInside = getNumberOfBadGuysInside()
->main
===main===
Is everything alright in there?
{
    -numberOfBadGuysInside == 0:
        Yes, it's pretty quiet. #postIt:Everything's good.
        ->TriesDialogue
    -numberOfBadGuysInside == 1:
        People are a bit nervous. There seems to have been an altercation with one of them.#postIt:People are a bit nervous.
        ->TriesDialogue
    -numberOfBadGuysInside == 2:
        They are quite uneasy. There have been several problems with some new members.
        If this keeps up they are going to end up killing each other.#postIt:They are quite uneasy.
        ->TriesDialogue
    -numberOfBadGuysInside == 3:
        This is chaos, several alternates have entered, they are killing each other.
        We can't do anything, they're all going to die.#postIt:They're all going to die.
        ->TriesDialogue
}

===TriesDialogue===
{
    -numberOfTries == 0:
        The signal is cutting out. I think you're only going to be able to make 2 more calls.#plusTries:1
        ->END
    -numberOfTries == 1:
        Signal's getting worse. You only have one call left.#plusTries:1
        ->END
    -numberOfTries == 2:
        <i>The call was cutt off. It doesn't seem you'll be able to make another call.</i>#plusTries:1
        ->END
}