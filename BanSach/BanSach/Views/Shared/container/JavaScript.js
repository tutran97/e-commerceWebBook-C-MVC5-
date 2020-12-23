var index = 0;
hienThiSlide(index);
hienThiSlideauto(index);
function hienThiSlideKeTiep() {
    index++;
    hienThiSlide();
}
function hienThiSlideKeTieplui() {
    index--;
    hienThiSlide();
}
function hienThiSlide() {
    var slides = document.getElementsByClassName("slide");
    if (index == slides.length) {
        index = 0;
    }
    if (index <0) {
        index = 3;
    }

    for (var i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slides[index].style.display = "block";
}
function hienThiSlideauto() {
    hienThiSlideKeTiep();
    index++;
    setTimeout(function(){hienThiSlideKeTiep()},1500)
}