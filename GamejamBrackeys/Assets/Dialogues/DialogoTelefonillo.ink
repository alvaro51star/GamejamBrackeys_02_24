EXTERNAL getNumberOfTries()
EXTERNAL getNumberOfBadGuysInside()
VAR numberOfTries = 0
~numberOfTries = getNumberOfTries()
VAR numberOfBadGuysInside = 0
~numberOfBadGuysInside = getNumberOfBadGuysInside()
->main
===main===
Is everything alright in there? #telefono:no
{
    -numberOfBadGuysInside == 0:
        Yes, it's pretty quiet. #postIt:Everything's good.#telefono:yes
        ->TriesDialogue
    -numberOfBadGuysInside == 1:
        People are a bit nervous. There seems to have been an altercation with one of them.#postIt:People are a bit nervous.#telefono:yes
        ->TriesDialogue
    -numberOfBadGuysInside == 2:
        They are quite uneasy. There have been several problems with some new members.
        If this keeps up they are going to end up killing each other.#postIt:They are quite uneasy.#telefono:yes
        ->TriesDialogue
    -numberOfBadGuysInside == 3:
        This is chaos, several alternates have entered, they are killing each other.
        We can't do anything, they're all going to die.#postIt:They're all going to die.#telefono:yes
        ->TriesDialogue
}

===TriesDialogue===
{
    -numberOfTries == 1:
        The signal is cutting out. I think you're only going to be able to make 2 more calls.#telefono:yes
        ->END
    -numberOfTries == 2:
        Signal's getting worse. You only have one call left.#telefono:yes
        ->END
    -numberOfTries == 3:
        <i>The call was cutt off. It doesn't seem you'll be able to make another call.</i>#telefono:no
        ->END
}