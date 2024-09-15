from django.shortcuts import render
from django.http import HttpResponseRedirect, HttpResponseNotFound
from .models import MusicAlbum

def hello_world(request):
    context = {'greeting': 'Hello world'}
    return render(request, 'index.html', context)


def index(request):
    albums = MusicAlbum.objects.all()
    return render(request, 'index.html', {"albums": albums})


def create(request):
    if request.method == "POST":
        album = MusicAlbum()
        album.name = request.POST.get("name")
        album.author = request.POST.get("author")
        album.genre = request.POST.get("genre")
        album.year = request.POST.get("year")
        album.save()
        return HttpResponseRedirect("/")
    else: 
        return render(request, "add.html")


def edit(request, id):
    try:
        album = MusicAlbum.objects.get(id=id)
        if request.method == "POST":
            album.name = request.POST.get("name")
            album.author = request.POST.get("author")
            album.genre = request.POST.get("genre")
            album.year = request.POST.get("year")
            album.save()
            return HttpResponseRedirect("/")
        else:
            return render(request, "edit.html", {"album": album})
        
    except MusicAlbum.DoesNotExist:
        return HttpResponseNotFound("<h2>Album not found</h2>")


def delete(request, id):
    try:
        album = MusicAlbum.objects.get(id=id)
        album.delete()
        return HttpResponseRedirect("/")
    except:
        return HttpResponseNotFound("<h2>Album not found</h2>")

# Create your views here.
