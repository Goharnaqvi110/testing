function howToCreateAd() {

    var imgSlider = `<div class="bootstrap-carousel">
                            <div id="carouselExampleIndicators2" class="carousel slide" data-bs-ride="carousel">
                                <div class="carousel-indicators">
                                    <button type="button" data-bs-target="#carouselExampleIndicators2" 
                                    data-bs-slide-to="0" class="active" aria-label="Slide 1" aria-current="true"></button>
                                    <button type="button" data-bs-target="#carouselExampleIndicators2" data-bs-slide-to="1"
                                    aria-label="Slide 2" class=""></button>
                                    <button type="button" data-bs-target="#carouselExampleIndicators2" data-bs-slide-to="2"
                                    aria-label="Slide 3" class=""></button>
                                    <button type="button" data-bs-target="#carouselExampleIndicators2" data-bs-slide-to="3"
                                    aria-label="Slide 4" class=""></button>
                                </div>
                                <div class="carousel-inner">
                                    <div class="carousel-item active">
                                        <img class="d-block w-100" style="max-height:400px;" src="/img/howtocreate/ad/1.png" alt="First slide">
                                        <div class="carousel-caption d-none d-md-block">                                                     
                                               <p>Create an ad for your property by filling out your property details and your
                                                preferred inspection times</p>
                                        </div>
                                    </div>                                     
                                    <div class="carousel-item">
                                        <img class="d-block w-100" style="max-height:400px;" src="/img/howtocreate/ad/2.png" alt="Second slide">
                                        <div class="carousel-caption d-none d-md-block">
                                               <p class="demo-desc">Once your ad is ready, click 'Go live'
                                               on the property card to publish your ad</p>
                                        </div>
                                    </div>
                                    <div class="carousel-item">
                                        <img class="d-block w-100" style="max-height:400px;" src="/img/howtocreate/ad/3.png" alt="Third slide">
                                        <div class="carousel-caption d-none d-md-block">
                                               <p>Your ad will be listed on our website</p>
                                        </div>
                                    </div>                                    
                                    <div class="carousel-item">
                                        <img class="d-block w-100" style="max-height:400px;" src="/img/howtocreate/ad/4.png" alt="Third slide">
                                        <div class="carousel-caption d-none d-md-block">
                                               <p>When you have found a suitable tenant, you can remove the
                                                ad by clicking 'Remove Ad' on the property card</p>
                                        </div>
                                    </div>                                    
                                </div>
                                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators2" data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Previous</span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators2" data-bs-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden" style="color:black">Next</span>
                                </button>
                            </div>
                        </div>
                        <div class="text-center">
                        <button type="button" class="btn btn-primary w-25" data-bs-dismiss="modal">Close
                        </button></div>`
    $('#modalTitle').empty().html('How to create an ad?');
    $('#accountSettingsContainer').empty().html(imgSlider);

}