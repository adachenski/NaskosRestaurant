function showFileSize() {
    var input, file;
    // (Can't use `typeof FileReader === "function"` because apparently
    // it comes back as "object" on some browsers. So just see if it's there
    // at all.)
    if (!window.FileReader) {
        bodyAppend("p", "The file API isn't supported on this browser yet.");
        return;
    }

    input = document.getElementById('fileinput');
    file = input.files[0]

    if (!input) {
        bodyAppend("p", "Um, couldn't find the fileinput element.");
    }
    else if (!input.files) {
        bodyAppend("p", "This browser doesn't seem to support the `files` property of file inputs.");
    }
    else {
        var fileinput = document.getElementById("submitForm");
        if (file.size < (1 * 1024 * 1024)) {
            fileinput.disabled = false;
            //bodyAppend("p", "File " + file.name + " is " + file.size + " bytes in size");
        }
        else {
            fileinput.disabled = true;
        }
    }
}

function bodyAppend(tagName, innerHTML) {
    var elm;
    var x = document.getElementById("warning-js");
    elm = document.createElement(tagName);
    elm.className = "upload-warning";
    elm.innerHTML = innerHTML;
    x.appendChild(elm);
}

