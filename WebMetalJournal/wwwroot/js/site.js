function Paging(PagingStatus) {
    if (PagingStatus == 0) {
        document.getElementById('ArrowLeft').style.display = 'inline-block';
        document.getElementById('ArrowRight').style.display = 'inline-block';

       
    }
    else if (PagingStatus == 1) {
        document.getElementById('ArrowRight').style.display = 'inline-block';

    }
    else if (PagingStatus == 2) {
        document.getElementById('ArrowLeft').style.display = 'inline-block';
    }
}
function Sound() {
    document.getElementById('SoundBook').play();
    п
}
