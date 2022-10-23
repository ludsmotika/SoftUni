function editElement(element, ref, newText) {
    while (element.textContent.indexOf(ref) != -1) {
        element.textContent = element.textContent.replace(ref, newText);
    }
}