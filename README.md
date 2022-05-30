# ArtNMusic
Use the Spotify API to Authenticate User
-https://developer.spotify.com/documentation/web-api/quick-start/

Make GET call to return top 100 Artists for Authenticated User
-https://developer.spotify.com/documentation/web-api/reference/#/operations/get-users-top-artists-and-tracks

User selects ONE of those artists in the Interface from a presented list.

Selected Artist is passed to the MusicBrainz API; return Albums for the Artist with title and GUID
https://musicbrainz.org/doc/MusicBrainz_API (using the Nuget MusicBrainz library)

App will then automatically chain the API call and hit the CoverArtArchive API, returning an array of hrefs to each Album Art Image.
https://coverartarchive.org/release/{mbid}

The user then selects a piece of album art and then selects from over 100 neural "style" templates.
https://neuralstyle.art/styles

The selection is passed to the Neural Style API and a new image is returned imbuing the selected style on the selected Album Art.
https://neuralstyle.art/api

A link to the GeneratedArt is then persisted to that Users profile.
/api/GeneratedImages
