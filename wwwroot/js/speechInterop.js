window.startSpeechRecognition = function (dotNetHelper) {
    const recognition = new webkitSpeechRecognition();
    recognition.lang = 'en-US';
    recognition.continuous = false;
    recognition.interimResults = false;

    recognition.onresult = function (event) {
        const transcript = event.results[0][0].transcript;
        dotNetHelper.invokeMethodAsync('ReceiveTranscript', transcript);
    };

    recognition.start();
};

window.speakText = function (text, lang) {
    const utterance = new SpeechSynthesisUtterance(text);
    utterance.lang = lang;
    speechSynthesis.speak(utterance);
};
