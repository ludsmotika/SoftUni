import { showHome, addTopic, clearHome } from './home.js';
import { showTopics } from './topics.js';

showHome();
document.getElementById('submitButton').addEventListener('click', (e) => { e.preventDefault(); addTopic(e); showTopics(); });
document.getElementById('cancelButton').addEventListener('click', clearHome);
showTopics();
