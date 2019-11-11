function solve() {
  const correctAnswers = [
    "onclick",
    "JSON.stringify()",
    "A programming API for HTML and XML documents"
  ];
  const results = {
    0: "You are recognized as top JavaScript fan!",
    1: correct => {
      return `You have ${correct} right answers`;
    }
  };

  let correctAnswered = 0;
  let questionIndex = 0;
  const resultsUl = document.getElementById("results");
  let currentActiveSection = Array.from(
    document.getElementsByTagName("section")
  ).filter(a => a.attributes.class === undefined)[questionIndex];

  const answerButtons = Array.from(document.getElementsByClassName("quiz-answer"));

  answerButtons.forEach(btn => {
    btn.addEventListener("click", clickHander);
  });

  function clickHander(e) {
    let answer = e.target.innerHTML;

    if (isCorrect(answer)) {
      correctAnswered++;
    }

    questionIndex++;

    if (isLastQuestion(questionIndex)) {
      endGame();

      return;
    }
    hideSection(currentActiveSection);
    currentActiveSection = document.getElementsByTagName("section")[
      questionIndex
    ];

    showSection(currentActiveSection);
  }
  function hideSection(section) {
    return section.style.display='none'
  }

  function showSection(section) {
    return section.style.display='block'
  }
  function isCorrect(answer) {
    return correctAnswers[questionIndex] === answer;
  }

  function isLastQuestion(questionIndex) {
    return questionIndex === correctAnswers.length;
  }
  function showResults(resultUl) {
    let resultMessage =
      correctAnswered % 3 === 0&&correctAnswered!==0
        ? results[0]
        : results[1](correctAnswered);
    let outputField = resultUl
      .getElementsByClassName("results-inner")[0]
      .getElementsByTagName("h1")[0];
    outputField.innerHTML = resultMessage;
    resultUl.style.display = "block";
  }

  function endGame() {
    hideSection(currentActiveSection);

    showResults(resultsUl);
  }
}
