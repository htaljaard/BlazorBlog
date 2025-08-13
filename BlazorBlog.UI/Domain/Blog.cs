using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorBlog.UI.Domain;

public class Blog
{
    public required Guid Id { get; set; } = Guid.CreateVersion7();

    [Required, MaxLength(100)]
    public required string Slug { get; set; }

    [Required, MaxLength(100)]
    public required string Title { get; set; }

    [Required]
    public required string Content { get; set; }

    [Required, MaxLength(200)]
    public required string Excerpt { get; set; }

    [Required, MaxLength(100)]
    public required string Author { get; set; }

    [Required]
    public required DateTime Created { get; set; }

    public Boolean isPublished { get; set; } = false;

}
