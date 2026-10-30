# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [5.7.2] - 2026-10-30
### Fixed
- `DownloadFile(File)` no longer fails with "An invalid request URI was provided" when `FilesOrigin` is empty or has no scheme: a file with `Id` is downloaded by `File.Url`, or from the `Origin` host if `File.Url` is not an absolute address.

### Notes
- Since 5.7.0 `FilesOrigin` is used for downloads, so it must be reachable from the client network.

## [5.7.1] - 2026-10-30
### Changed
- `DownloadFile(File)` downloads link attachments by `Url` without the access token instead of returning `ErrorCode.FileIsMissing`, as before 5.7.0 but without the token. The response may be a web page, not the file.
- `DownloadFile(File)` with `Id` uses `File.Url` when its host is the `Origin`/`FilesOrigin` host, which restores self-hosted installations under a path prefix.

## [5.7.0] - 2026-10-28
### Breaking
- `DownloadFile(File)` does not download link attachments (no size and MD5) and returns `ErrorCode.FileIsMissing`; `EnsureSuccess()` on such a file now throws.
- `UploadFile` with the static `PyrusClient.Settings` where only `Origin` or only `FilesOrigin` is changed: uploads go to `{Origin}/files/upload` instead of `FilesOrigin`.

### Changed
- `DownloadFile(File)` with `Id` downloads from an address built from `Origin`/`FilesOrigin`; `File.Url` is ignored.
- `DownloadFile(File)` without `Id` sends the access token only if the scheme matches and the host is the `Origin`/`FilesOrigin` host or its parent domain (e.g. `pyrus.com`).
- Self-hosted with only `Origin` set: files are downloaded from `/services/attachment` on the `Origin` host.
- `UploadFile` and `DownloadFile(File)` choose between `Origin` and `FilesOrigin` by comparing them with the Pyrus defaults, not with the static `PyrusClient.Settings`.
- An invalid `Origin` in `DownloadFile(File)` is reported as `PyrusApiClientException`.

## [2.1.14] - 2019-06-11
### Added
- This CHANGELOG file.
- added new error codes.
- schedule task to utc date with time.
- return decimal_places for form field number
- return task current step

### Changed
- Fixed closing file stream on retry
