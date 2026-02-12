function changeStyle() {
    let p = document.getElementById("para");

    p.style.fontFamily = getValue("fontFamily");
    p.style.textAlign = getValue("textAlign");
    p.style.lineHeight = getValue("lineHeight");
    p.style.letterSpacing = getValue("letterSpacing");
    p.style.textIndent = getValue("textIndent");
    p.style.textTransform = getValue("textTransform");
    p.style.textDecoration = getValue("textDecoration");
}

function getValue(radioName) {
    let items = document.getElementsByName(radioName);
    for (let i of items) {
        if (i.checked) return i.value;
    }
    return "";
}
