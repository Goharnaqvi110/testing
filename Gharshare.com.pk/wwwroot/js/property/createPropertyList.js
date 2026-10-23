function createPropertyList(properties) {
    var html = '';
    for (let property of properties) {
        html += `<div class="col-lg-4 col-sm-6 col-12">
                    <div class="ltn__blog-item ltn__blog-item-3">
                        <div class="ltn__blog-img">
                            <a href="/property/detail?uid=${property.uid}">
                                <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel" data-interval="false">
                                    <ol class="carousel-indicators">
                                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                                    </ol>
                                    <div class="carousel-inner">
                                        <div class="carousel-item active">
                                            <img src="${property.coverImage}" class="d-block w-100" alt="..." style="min-height:300px;">
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="ltn__blog-brief">
                            <div class="ltn__blog-meta">
                                <ul>
                                    <li class="ltn__blog-author">
                                        <h6><span>Rs.</span> ${formatValue(property.rent)}/month</h6>
                                    </li>
                                </ul>
                                <div class="ltn__blog-meta">
                                    <div class="row">
                                        <div class="col-md-7">
                                            <i class="fa fa-bath" style="color: #5c727d;"> <span>${property.bathroom}</span></i>
                                            <i class="fa fa-bed" style="color: #5c727d;"> <span>${property.bed}</span></i>
                                            <i class="fa fa-user" style="color: #5c727d;"> <span>${property.totalflatmates !== null ? property.totalflatmates : "0"}</span></i>
                                        </div>
                                        <div class="col-md-5">
                                            <ul>
                                                <li>
                                                    <p>${getPropertyType(property.catogryID)}</p>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <p><a href="/property/detail?uid=${property.uid}">
                                ${getShortDescription(property.description,25)}</a>
                                </p>
                                <div class="ltn__blog-btn">
                                    ${Available(property.availableFrom)}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>`;
    }
    $('#propertyList').append(html);
}