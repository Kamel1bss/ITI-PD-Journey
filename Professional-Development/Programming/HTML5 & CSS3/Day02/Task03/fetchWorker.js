self.onmessage = function (e) {
    // let url = "https://picsum.photos/v2/list";
    let url = e.data;
    let xhr = new XMLHttpRequest();
    xhr.open('GET',url)
    xhr.send("")
    xhr.onreadystatechange = function(){
        if(xhr.readyState ===4 && xhr.status === 200){
            let data = xhr.responseText
            data = JSON.parse(data)
            self.postMessage(data);
        }
    }
};
